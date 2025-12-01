using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using CalculadoraAPI;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CalculadoraAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Calculadora API - Proyecto 2");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Calculadora API");
                });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\CalculadoraAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}