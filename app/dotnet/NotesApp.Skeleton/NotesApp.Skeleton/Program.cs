using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NotesApp.Skeleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string serverName = "LocalDEV";
            if (args.Length > 0)
            {
                serverName = args[0];
            }

            BuildWebHost(args, serverName).Run();
        }

        public static IWebHost BuildWebHost(string[] args, string serverName) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:80")
                .UseStartup<Startup>()
                .UseSetting("serverName", serverName)
                .Build();
    }
}
