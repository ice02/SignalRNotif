using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SignalRNotif.Service
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
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
        }
    }
}
