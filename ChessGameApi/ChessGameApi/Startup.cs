using AutoMapper;
using ChessGameApi.Domain;
using ChessGameApi.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChessGameApi
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

            services.AddMvc();

            services.AddControllers();

            services.AddCors(o => o.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ServiceSingleton(services);

            ServiceScope(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAnyOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ServiceSingleton(IServiceCollection services)
        {
            services.AddSingleton<IGameRepository, GameRepository>();
        }
        
        private void ServiceScope(IServiceCollection services)
        {
            services.AddScoped<IMoveRepository, MoveRepository>();
        }
    }
}
