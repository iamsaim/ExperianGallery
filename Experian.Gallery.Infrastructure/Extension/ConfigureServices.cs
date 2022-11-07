using Experian.Gallery.Application.Common.Contracts;
using Experian.Gallery.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Experian.Gallery.Infrastructure.Extension
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IGalleryService, GalleryService>();

            return services;
        }
    }
}
