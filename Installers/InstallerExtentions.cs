using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace handnotes.Installers
{
    public static class InstallerExtentions
    {
        public static void InstallServicesInAssembly (this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(installer => typeof(IInstaller).IsAssignableFrom(installer) && !installer.IsInterface && !installer.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(configuration, services));
        }
    }
}