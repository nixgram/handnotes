using handnotes.Data;
using handnotes.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace handnotes.Installers
{
    public class DataInstaller:IInstaller
    {
        public void InstallServices (IConfiguration Configuration, IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgresHeroku")));

            services.AddScoped<IPostService, PostService>();

        }
    }
}