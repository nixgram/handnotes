using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace handnotes.Configurations
{
    public class ServerAddressesMiddleware
    {
        private readonly IFeatureCollection _features;
        public ServerAddressesMiddleware (RequestDelegate _, IServer server)
        {
            _features = server.Features;
        }

        public async Task Invoke (HttpContext context)
        {
            // fetch the addresses
            var addressFeature = _features.Get<IServerAddressesFeature>();
            var addresses = addressFeature.Addresses;

            // Write the addresses as a comma separated list
            await context.Response.WriteAsync(string.Join(",", addresses));
        }
    }
}