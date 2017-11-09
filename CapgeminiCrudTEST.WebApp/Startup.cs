using CrudTT.Core.IoC;
using CrudTT.Core.Repositories;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(CrudTT.WebApp.Startup))]

namespace CrudTT.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            var settings = config.Formatters.JsonFormatter.SerializerSettings;


            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            settings.Formatting = Formatting.Indented;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(config);
        }

        private static IKernel CreateKernel()
        {


            var kernel = new StandardKernel(new MappingModule());
            try
            {
                kernel.Load(Assembly.GetExecutingAssembly());



                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
        }


    }
}