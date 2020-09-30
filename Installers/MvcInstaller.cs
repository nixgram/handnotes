using System;
using handnotes.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace handnotes.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices (IConfiguration Configuration, IServiceCollection services)
        {
            var admin = new Admin();
            Configuration.Bind(nameof(Admin), admin);
            services.AddSingleton(admin);
            Console.WriteLine($"Developed By : {admin.Name} - {admin.Access} {admin.Role}");
            services.AddControllersWithViews();
            //services.AddRazorPages();

            // Swagger Documentation's Config 
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Hand Notes",
                    Version = "v1",
                    Description = "Sample service for Learning...",
                });

            });


        }
    }
}
