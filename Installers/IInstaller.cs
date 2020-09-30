using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace handnotes.Installers
{
    public interface IInstaller
    {
        void InstallServices (IConfiguration Configuration, IServiceCollection services);
    }
}