using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MiscUtility.SwaggerUtility
{
    public static class SwaggerConfigurationExtensionMethods
    {
        public static void ConfigureSwaggerService(
            this IServiceCollection serviceCollection, List<SwaggerDocumentInfo> swaggerDocumentInfos)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            _ = serviceCollection.AddSwaggerGen(c =>
              {
                  swaggerDocumentInfos.ForEach(x =>
                  {
                      c.SwaggerDoc(x.SwaggerApiVersion, x.SwaggerApiInfo);
                  });
              });
        }
        public static void ConfigureSwaggerMiddleWare(
            this IApplicationBuilder app, List<SwaggerEndpoint> swaggerEndpoints)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            _ = app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            _ = app.UseSwaggerUI(c =>
              {
                  swaggerEndpoints.ForEach(x =>
                  {
                      c.SwaggerEndpoint(x.EndpointUrl, x.EndPointName);
                  });
              });
        }
    }
}
