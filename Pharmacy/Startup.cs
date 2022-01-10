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
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Services;
using System.IO;
using Microsoft.Extensions.FileProviders;

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
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(CreateConnectionStringFromEnvironment()));
            services.AddMvc();
            services.AddControllers();
            services.AddCors();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());


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

            server = new Server
            {
                Services = { MedicineService.BindService(new MedicineAvailabilityService()) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);

        }

        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }

      private string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "drugstoredb";
            var user = GetSecretOrEnvVar("db_user") ?? "root";
            var password = GetSecretOrEnvVar("db_pass") ?? "root";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "true";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

            string retVal = "Server=" + server + ";Port=" + port + ";Database=" + database + ";User ID=" + user + ";Password=" + password + ";Integrated Security=" + integratedSecurity + ";Pooling=" + pooling + ";";
            return retVal;
        }

        private string GetSecretOrEnvVar(string key)
        {
            const string DOCKER_SECRET_PATH = "/run/secrets/";
            Console.WriteLine("JKFJFJKFAK");
            if (Directory.Exists(DOCKER_SECRET_PATH))
            {
                Console.WriteLine("OVDE SAM");
                IFileProvider provider = new PhysicalFileProvider(DOCKER_SECRET_PATH);
                IFileInfo fileInfo = provider.GetFileInfo(key);
                if (fileInfo.Exists)
                {
                    Console.WriteLine("POSTOJI FAJL");
                    using (var stream = fileInfo.CreateReadStream())
                    using (var streamReader = new StreamReader(stream))
                    {
                        String retVal = streamReader.ReadToEnd();
                        Console.WriteLine(retVal);
                        return retVal;
                    }
                }
            }

            return Configuration.GetValue<string>(key);
        }
    }
}
