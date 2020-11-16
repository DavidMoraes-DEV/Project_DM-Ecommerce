﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommercee
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services) /* Configuracoes de servicos */
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles(); /* Esse comando permite utilizar arquivos padroes */
            app.UseStaticFiles(); /*Para que seja possível que os arquivos estáticos sejam acessados se faz necessário o uso desse comando: " app.UseStaticFile(); "*/
            app.UseCookiePolicy();

            /*
             * https://www.site.com.br -> Qual controlador? Sendo que será o controlador que irá pegar os Models e Views e vai fazer com que isso seja apresentado da maneira correta, pois o controlador tem o papel da gestão das requisições.
             * -> Rotas: É Quem define qual controlador será acessado, pois as rotas são caminhos ou pré-definicoes de caminhos que levam a um determinado controlador
             * https://(Protocolo)www.site.com.br(Domínio e opcionalmente podemos colocar a porta ou deixar que coloque a porta padrao do protocolo)/{...caminho...}?{Querystring}#{Fragmento}
             * O "Caminho" no caso do padrao ASP.NET Core MVC é o parametro utilizado para personalizar
             *
             */

            /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); * O primeiro parâmetro do template e destinado ao controlador que nesse caso foi "HOME", Ja o segundo parametro he destinado a alguma acao relacionada ao home por exemplo e o terceiro parametro he opcional sendo um id
            });*/
        }
    }
}
