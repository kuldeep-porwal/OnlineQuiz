using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace MiscUtility.SwaggerUtility
{
    public class SwaggerConfiguration
    {
        public List<SwaggerDocumentInfo> SwaggerDocumentInfos { get; set; }
        public List<SwaggerEndpoint> SwaggerEndpoints { get; set; }
    }

    public class SwaggerDocumentInfo
    {
        public string SwaggerApiVersion { get; set; }
        public OpenApiInfo SwaggerApiInfo { get; set; }
    }

    public class SwaggerEndpoint
    {
        public string EndpointUrl { get; set; }
        public string EndPointName { get; set; }
    }
}
