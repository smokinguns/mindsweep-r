using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using System.Web.Http;

using BrockAllen.MembershipReboot;


using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot.Relational;
using System.Web;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using MinesweepR.Api.Util;
using Newtonsoft.Json;
using MinesweepR.Api.Controllers;
using MinesweepR.Api.Service;

[assembly: OwinStartup(typeof(MinesweepR.Api.Startup))]

namespace MinesweepR.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureWebApi(app);       

            // Branch the pipeline here for requests that start with "/signalr"
            
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();
            var serializer = JsonSerializer.Create(settings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);

            app.Map("/signalr", map =>
            {
                // Turn cross domain on 
       
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    //  EnableJSONP = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
                
            });
        }
        public void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var container = new UnityContainer();

            //var memconfig = new MembershipRebootConfiguration();
            //memconfig.PasswordHashingIterationCount = 50000;
            //memconfig.MultiTenant = false;

            //container.RegisterType<UserController>(new InjectionFactory(c => (new UserController(new UserAccountService(memconfig, new DefaultUserAccountRepository(new DefaultMembershipRebootDatabase("MembershipReboot")))))));
            container.RegisterType<GameBoardController>(new InjectionFactory(c => new GameBoardController(new GameBoardService())));
            container.RegisterType<PlayersController>(new InjectionFactory(c => new PlayersController(new UserService())));
            container.RegisterType<GamesController>(new InjectionFactory(c => new GamesController(new GameService())));
            
            config.DependencyResolver = new UnityResolver(container);
            var cors = new EnableCorsAppSettingsAttribute("");
            config.EnableCors(cors);
            
            var formatters =config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
    }
}
