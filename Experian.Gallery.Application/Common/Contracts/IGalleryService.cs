using Experian.Gallery.Application.Common.Dto;

namespace Experian.Gallery.Application.Common.Contracts;

public interface IGalleryService
{
    Task<IEnumerable<GetAlbumDTO>> GetGallery();

}