using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyCourse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Crea un WebHost : contiene tutti i componenti a diretto contato con il mondo esterno. Il componente in grado di riceve ed elaborare un richiesta http si chiama web server (Kestrel : costruito ad hoc per asp.net core)
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
