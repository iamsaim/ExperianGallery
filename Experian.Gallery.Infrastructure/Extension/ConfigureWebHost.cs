using Microsoft.Extensions.Hosting;

namespace Experian.Gallery.Infrastructure.Extension
{
    public static class ConfigureWebHost
    {
        public static IHostBuilder CreateDefaultHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .AddLogging();
        }
            
    }
}