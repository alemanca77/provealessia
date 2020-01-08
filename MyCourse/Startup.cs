using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // qui passa solo se nel launchSettings.json delle properties ho specificato: "ASPNETCORE_ENVIRONMENT": "Development"
            if (env.IsDevelopment())  
            {
                //1° middleware
                 app.UseDeveloperExceptionPage(); 
            }

            // 2° middleware (per file statici) (è anadato a vedere all'interno dell'oggetto httpcontext e ha visto che il percorso digitato (https://localhost:5001/CA_INDOSUEZ_.jpg) corrisponde esattamente a un file fisico 
            // all'interno della directory wwwroot)
            app.UseStaticFiles();

            //ultimo middleware
            app.Run(async (context) => 
            {
                string nome = context.Request.Query["nome"];
                await context.Response.WriteAsync($"Hello {nome}!");
            });
        }
    }
}