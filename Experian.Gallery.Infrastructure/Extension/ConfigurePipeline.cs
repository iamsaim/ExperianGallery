using Experian.Gallery.Application.Common.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Experian.Gallery.Infrastructure.Extension
{
    public static class ConfigurePipeline
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<UnhandledExceptionMiddleware>();
        }
    }
}