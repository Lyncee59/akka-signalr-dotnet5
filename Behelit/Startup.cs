using Behelit.Common.Interfaces;
using Behelit.Core;
using Behelit.Hubs;
using Behelit.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameServer
{

    public class Startup
    {
         public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .WithOrigins("http://localhost:3000", "https://localhost:44303/")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));

            services.AddControllers();

            services.AddSpaStaticFiles(configure =>
            {
                configure.RootPath = "client/build";
            });

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            services.AddSingleton<IRandomService, RandomService>();
            services.AddSingleton<ISignalREventsPusher, SignalREventsPusher>();
            services.AddSingleton<ISignalRProcessor, AkkaService>();

            services.AddHostedService<AkkaService>(sp => (AkkaService)sp.GetRequiredService<ISignalRProcessor>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageHub>("/message");
  
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });
        }
    }
}
