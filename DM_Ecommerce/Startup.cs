
using DM_Ecommerce.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DM_Ecommerce.Models.Repositories.Contracts;
using DM_Ecommerce.Models.Repositories;

namespace DM_Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services) /* Configuracoes de servicos */
        {
            //Padrão Repository
            services.AddScoped<IClientRepository, ClientRepository>(); /* Configura para que quando essas estruturas forem necessárias o código entregue por meio da Interface o acesso aos métodos que contem na classe ClientRepository */
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /* Session - Configuração */
            services.AddMemoryCache(); /* Guarda os dados na memória */
            services.AddSession(options => { /* ... */ }); /* Adiciona Sessão */

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Caminho do Banco de Dados e como será a conexão com ele
            string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DM_Ecommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; /* Para encontrar a string de conexao do localDb, ir na aba "SQL Server Object Explorer" e entre ou crie ou Banco de dados SQL Server, depois vai em propriedades e copie o endereço do Connection string que foi construída para o Banco de Dados criado e cole dentro da variável "connection" */

            services.AddDbContext<DM_EcommerceContext>(options => options.UseSqlServer(connection));
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles(); /* Esse comando permite utilizar arquivos padroes */
            app.UseStaticFiles(); /*Para que seja possível que os arquivos estáticos sejam acessados se faz necessário o uso desse comando: " app.UseStaticFile(); "*/
            app.UseCookiePolicy();
            app.UseSession();

            /*
             * https://www.meusite.com.br -> Qual controlador? Sendo que será o controlador que irá pegar os Models e Views e vai fazer com que isso seja apresentado da maneira correta, pois o controlador tem o papel da gestão das requisições.
             * -> Rotas: É Quem define qual controlador será acessado, pois as rotas são caminhos ou pré-definicoes de caminhos que levam a um determinado controlador
             * https://(Protocolo)www.site.com.br(Domínio e opcionalmente podemos colocar a porta ou deixar que coloque a porta padrao do protocolo)/{...caminho...}?{Querystring}#{Fragmento}
             * O "Caminho" no caso do padrao ASP.NET Core MVC é o parametro utilizado para personalizar
             *
             */

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "/{controller=Home}/{action=Index}/{id?}"); /* O primeiro parâmetro do template é destinado ao controlador que nesse caso foi "HOME", Ja o segundo parametro he destinado a alguma acao relacionada ao home por exemplo e o terceiro parametro he opcional sendo um id */
            });
        }
    }
}
