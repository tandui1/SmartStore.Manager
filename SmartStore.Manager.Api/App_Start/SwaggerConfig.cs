using System.Web.Http;
using WebActivatorEx;
using SmartStore.Manager.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SmartStore.Manager.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "swagger");
                        c.IncludeXmlComments(GetXmlCommentsPath());

                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
