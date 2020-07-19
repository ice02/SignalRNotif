using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SignalRNotif.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            GlobalHost.DependencyResolver.UseStackExchangeRedis("localhost", 6379, "", "SignalRNotif");

            app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                var hubConfigration = new HubConfiguration
                {
                    EnableJSONP = true,
                    EnableJavaScriptProxies = false,
                    EnableDetailedErrors = true
                };
                map.RunSignalR(hubConfigration);
            });
            //app.MapAzureSignalR(this.GetType().FullName);


        }
    }
}
