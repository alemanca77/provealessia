using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            // 2° middleware (per file statici) (è andato a vedere all'interno dell'oggetto httpcontext e ha visto che il percorso digitato (https://localhost:5001/CA_INDOSUEZ_.jpg) corrisponde esattamente a un file fisico 
            // all'interno della directory wwwroot)
            app.UseStaticFiles();

            // 3° middleware di Routing : se nella barra del url scriviamo "/Courses/Detail/5" quando la richiesta arriva a questo middleware che verifica :
            // l'utente ha chiesto Courses e quindi verifico se esiste all'interno dell'applicazione un CoursesController (esiste). 
            // Esiste anche un action Detail in questo Controller?? esiste e può gestire la richiesta restitundo un risultato.
            
            // app.UseMvcWithDefaultRoute();  => fa esattamente quello che c'è sotto

            // UseMvc accetta come parametro una funzione
            app.UseMvc(routeBuilder => 
            {
                routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}