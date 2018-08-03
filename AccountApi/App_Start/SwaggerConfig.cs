using System.Web.Http;
using WebActivatorEx;
using AccountApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AccountApi
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "AccountApi");
                c.IncludeXmlComments(GetXmlCommentsPath());
                // c.OperationFilter<HttpHeaderFilter>();  // 权限过滤

            }).EnableSwaggerUi(c => {
                c.DocumentTitle("系统开发接口");
                // 使用中文
                c.InjectJavaScript(thisAssembly, "AccountApi.Scripts.swagger_lang.js");
            });
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/AccountApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
