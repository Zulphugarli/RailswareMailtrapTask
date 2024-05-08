using Microsoft.Extensions.DependencyInjection;
using RailswareMailtrap.Application.Interfaces;
using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Infrastructure.Services;

namespace RailswareMailtrap.Infrastructure
{
    public static class InfrastructureDependencyInjectionss
    {
        public static IServiceCollection AddMailSenderServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(FileMappingProfile)); // only the assembly containing this profile
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
