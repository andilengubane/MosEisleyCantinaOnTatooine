using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MosEisleyCantinaOnTatooine.Persistence;
using MosEisleyCantinaOnTatooine.Service;
using MosEisleyCantinaOnTatooine.Service.Interface;
using System.IO;
using System.Reflection;

namespace MosEisleyCantinaOnTatooine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mos Eisley Cantina On Tatooine.API", Version = "v1" });
            });
            services.AddDbContext<MosEisleyCantinaOnTatooineDbContext>(options => options.UseSqlServer("Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=MosEisleyCantinaOnTatooine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddScoped<IMenuItemsService, MenuItemsService>();

            services.AddScoped<IMenuItemsService, MenuItemsService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MosEisleyCantinaOnTatooine.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
