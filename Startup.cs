using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using projeto_cs1;
using projeto_cs1.Models;

namespace projeto_cs1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("MyDbContext");
                if (Environment.IsDevelopment())
                {
                    // Substitua "YourServerVersion" pela versão do seu servidor MySQL
                    options.UseNpgsql(connectionString);
                }
                else
                {
                    //options.UseSqlServer(connectionString);
                }
            });


            // Adicione outros serviços aqui
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
        }
    }
}
