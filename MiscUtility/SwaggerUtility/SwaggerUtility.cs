using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MiscUtility.SwaggerUtility
{
    public class SwaggerUtility
    {
        public static SwaggerConfiguration GetSwaggerConfiguration(IConfiguration configuration)
        {
            SwaggerConfiguration swaggerConfiguration = new SwaggerConfiguration();
            configuration.GetSection("Swagger").Bind(swaggerConfiguration);
            return swaggerConfiguration;
        }
        public static List<SwaggerDocumentInfo> GetSwaggerDocumentInfoConfiguration(IConfiguration configuration)
        {
            List<SwaggerDocumentInfo> swaggerDocumentInfos = new List<SwaggerDocumentInfo>();
            configuration
                .GetSection("Swagger")
                .GetSection("SwaggerDocumentInfos")
                .Bind(swaggerDocumentInfos);
            return swaggerDocumentInfos;
        }
        public static List<SwaggerEndpoint> GetSwaggerEndpointConfiguration(IConfiguration configuration)
        {
            List<SwaggerEndpoint> swaggerEndpoints = new List<SwaggerEndpoint>();
            configuration
                .GetSection("Swagger")
                .GetSection("SwaggerEndpoint")
                .Bind(swaggerEndpoints);
            return swaggerEndpoints;
        }
    }
}
