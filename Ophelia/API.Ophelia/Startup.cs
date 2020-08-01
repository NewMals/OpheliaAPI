using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.Ophelia.Milddleware;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infraestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Ophelia
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //Configura Cors
            services.AddCors(option => option.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            //Inicia MVC
            services.AddMvc();

            //Configura AutoFac para inyección de dependencias
            var builder = new ContainerBuilder();

            //Configura la inyección del contexto de base de datos
            try
            {
                builder.RegisterType<ContextoFacturacion>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al inicializar el contexto de bases de datos", ex);
            }

            //Configura inyección de interfaces
            try
            {
                builder.RegisterAssemblyTypes(Assembly.Load("Infraestructura.Ophelia"))
                    .Where(x => x.Namespace.Contains("Repositorios"))
                    .AsImplementedInterfaces();

                builder.RegisterAssemblyTypes(Assembly.Load("ServiciosAplicacion.Ophelia"))
                    .AsImplementedInterfaces();

                builder.Populate(services);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al configurar la inyeción de dependencias", ex);
            }
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //milddleware de error
            app.UseMiddleware(typeof(ErrorMilddleware));

            //Aplica configuración de CORS
            app.UseCors("AllowAll");

            //Inicia API
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

        }
    }
}
