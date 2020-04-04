using Microsoft.Extensions.Configuration;
using MiscUtility.ConfigurationUtility;
using System.Collections.Generic;

namespace MiscUtility.SwaggerUtilities
{
    public class SwaggerUtility
    {
        public static SwaggerConfiguration GetSwaggerConfiguration(IConfiguration configuration)
        {
            return configuration.BindAndReturn<SwaggerConfiguration>("Swagger");
        }

        public static List<SwaggerDocumentInfo> GetSwaggerDocumentInfoConfiguration(IConfiguration configuration)
        {
            return SwaggerSectionWiseConfiguration<List<SwaggerDocumentInfo>>(configuration, "SwaggerDocumentInfos");
        }
        public static List<SwaggerEndpoint> GetSwaggerEndpointConfiguration(IConfiguration configuration)
        {
            return SwaggerSectionWiseConfiguration<List<SwaggerEndpoint>>(configuration, "SwaggerEndpoints");
        }

        public static T SwaggerSectionWiseConfiguration<T>(IConfiguration configuration, string sectionName) where T : new()
        {
            return configuration.GetSection("Swagger").BindAndReturn<T>(sectionName);
        }
    }
}
