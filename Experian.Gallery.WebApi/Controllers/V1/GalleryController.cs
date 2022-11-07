using Experian.Gallery.Application.Common.Contracts;
using Experian.Gallery.Application.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Experian.Gallery.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/gallery")]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _albumService;

        public GalleryController(IGalleryService albumService)
        {
            _albumService = albumService;
        }

        [Route("{userid}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAlbumDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAlbums(int userid)
        {
            var list = await _albumService.GetGallery();
            var userList = list.Where(x => x.UserId == userid);
            if (userList.Count() == 0)
                return NotFound("No data against this user");
            else
                return Ok(userList);
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAlbumDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAlbums()
        {
            var list = await _albumService.GetGallery();

            return Ok(list);

        }
    }
}
