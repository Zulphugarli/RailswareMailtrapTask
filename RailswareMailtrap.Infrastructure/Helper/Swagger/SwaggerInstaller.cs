using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace RailswareMailtrap.Infrastructure.Helper.Swagger
{
    public static class SwaggerInstaller
    {
        private static string? _swaggerTitle = Assembly.GetEntryAssembly().GetName().Name;

        public static string? SwaggerTitle
        {
            get { return _swaggerTitle; }
        }

        public static void SetSwaggertitle(string title)
        {
            _swaggerTitle = title;
        }

        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services, Action<SwaggerGenOptions> setupAction = null)
        {

            if (setupAction != null)
            {
                //services.ConfigureSwaggerGen(setupAction);
                services.AddSwaggerGen(setupAction);
                return services;
            }




            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                AddSwaggerXml(options);
            });
            return services;
        }

        static void AddSwaggerXml(SwaggerGenOptions c)
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlFile in xmlFiles)
            {
                c.IncludeXmlComments(xmlFile);
            }
        }
        public static IApplicationBuilder UseMailTrapSwaggerUI(this IApplicationBuilder app, Action<SwaggerUIOptions> setupAction = null)
        {
            var apiVersionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();


            SwaggerUIOptions options;
            if (setupAction != null)
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<SwaggerUIOptions>>().Value;
                    setupAction?.Invoke(options);
                }

                app.UseSwagger();
                app.UseSwaggerUI(options);
            }
            else
            {

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
    }
}
