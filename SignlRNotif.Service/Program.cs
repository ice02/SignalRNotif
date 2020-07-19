using Microsoft.Owin.Hosting;
using System;
using System.Linq;

namespace SignalRNotif.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = "11111";

            if (args.Count() > 0)
            {
                port = args[0];
            }

            using (WebApp.Start<Startup>($"http://localhost:{port}"))
            {
                Console.WriteLine($"Hub on  http://localhost:{port}");
                Console.ReadLine();
            }
        }
    }
}
