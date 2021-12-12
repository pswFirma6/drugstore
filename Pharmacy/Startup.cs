using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyLibrary.Model;
using Grpc.Core;

namespace Pharmacy
{
    public class Startup
    {
        private Server server;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql("server = localhost; port = 5432; database = drugstoredb; username = root; password = root"));

            services.AddControllers();
            services.AddCors();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

        
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // creating server
            server = new Server
            {
                Services = { NetGrpcService.BindService(new MedicineAvailabilityService()) },
                Ports = { new ServerPort("localhost", 8787, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutDown);

        }

        private void OnShutDown()
        {
            if(server != null)
            {
                server.ShutdownAsync().Wait();
            }
        }

    }
}
