using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RailswareMailtrap.Infrastructure.Helper.Swagger
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        private string _hostname = Environment.GetEnvironmentVariable("AWS_API_DOMAIN");
        private string _awsConnectionId = Environment.GetEnvironmentVariable("AWS_API_CON_ID");
        public string HostName => _hostname;
        private string? _constructorvalue = default;
        private readonly IConfiguration _iconfig;
        public SwaggerDocumentFilter(IConfiguration configuration)
        {
            _iconfig = configuration;
        }



        public void ReadEnvValues()
        {
            _hostname = Environment.GetEnvironmentVariable("AWS_API_DOMAIN");
            _awsConnectionId = Environment.GetEnvironmentVariable("AWS_API_CON_ID");

            if (string.IsNullOrWhiteSpace(_hostname))
            {
                string? hostString = _iconfig?.GetSection("AWS_API_DOMAIN").Value;
                _hostname = hostString;
            }
        }
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            ReadEnvValues();

            foreach (var pathItem in swaggerDoc.Paths)
            {
                foreach (var operation in pathItem.Value.Operations)
                {
                    if (!operation.Value.Extensions.ContainsKey("x-amazon-apigateway-integration"))
                    {
                        var integrationData = new OpenApiObject
                        {
                            ["connectionId"] = new OpenApiString(_awsConnectionId ?? "tl20e9"),
                            ["httpMethod"] = new OpenApiString(operation.Key.ToString().ToUpper()),
                            ["uri"] = new OpenApiString($"{_hostname}{pathItem.Key}"),
                            ["responses"] = new OpenApiObject
                            {
                                ["default"] = new OpenApiObject
                                {
                                    ["statusCode"] = new OpenApiString("200")
                                }
                            },
                            ["passthroughBehavior"] = new OpenApiString("when_no_match"),
                            ["connectionType"] = new OpenApiString("VPC_LINK"),
                            ["type"] = new OpenApiString("http")
                        };


                        operation.Value.Extensions.Add("x-amazon-apigateway-integration", integrationData);
                    }
                }
            }
        }
    }
}
