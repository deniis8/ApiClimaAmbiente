using ApiClimaAmbiente.Data;
using ApiClimaAmbiente.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace ApiClimaAmbiente
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string ambiente = "ServerConnectionClimaAmbiente";// "ServerConnectionClimaAmbiente";
            services.AddDbContextPool<AppDbContext>(options => options
                   .UseMySql(
                       Configuration.GetConnectionString(ambiente),
                       mySqlOptions => mySqlOptions.ServerVersion(new Version(10, 6, 10), ServerType.MariaDb)
                   )
               );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ClimaAmbienteService, ClimaAmbienteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
        options => options.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin() //AllowAnyOrigin().AllowAnyHeader()
    );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}