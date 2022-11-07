using Experian.Gallery.Application.Common.Contracts;
using Experian.Gallery.Application.Common.Dto;
using Microsoft.Extensions.Logging;
using Experian.Gallery.Infrastructure.HTTPClientWrapper;
using Microsoft.Extensions.Configuration;
using Experian.Gallery.Infrastructure.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Experian.Gallery.Application.Common.Contants;

namespace Experian.Gallery.Infrastructure.Services;

public class GalleryService : IGalleryService
{

    private readonly ILogger<GalleryService> _logger;
    private readonly IConfiguration _configuration;
    private IMemoryCache _cache;

    public GalleryService(ILogger<GalleryService> logger,
        IConfiguration configuration,
        IMemoryCache cache)
    {
        _logger = logger;
        _configuration = configuration;
        _cache = cache;
    }

    public async Task<IEnumerable<GetAlbumDTO>> GetGallery()
    {
        _logger.LogInformation("retriving albums");

        IEnumerable<GetAlbumDTO> albums;

        if (!_cache.TryGetValue(ApplicationContants._CacheKey, out albums))
        {
            var albumCall = GetAlbumsFromAPI(_configuration.GetSection("APIUri").Get<APIUri>().AlbumUri);
            var photosCall = GetPhotosAPI(_configuration.GetSection("APIUri").Get<APIUri>().PhotosUri);

            await Task.WhenAll(albumCall, photosCall);
            albums = await albumCall;
            var photos = await photosCall;

            foreach (var album in albums)
                album.photos = photos.Where(x => x.AlbumId == album.Id);
            
            var cacheExpirationOptions = new MemoryCacheEntryOptions();
            cacheExpirationOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(30);

            _cache.Set(ApplicationContants._CacheKey, albums, cacheExpirationOptions);


        }

        return albums;
    }

    private async Task<IEnumerable<GetAlbumDTO>> GetAlbumsFromAPI(string URI)
    {

        return await HTTPClientWrapper<IEnumerable<GetAlbumDTO>>.Get(URI);


    }

    private async Task<IEnumerable<GetPhotoDTO>> GetPhotosAPI(string URI)
    {

        return await HTTPClientWrapper<IEnumerable<GetPhotoDTO>>.Get(URI);


    }
}