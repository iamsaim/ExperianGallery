using Experian.Gallery.Application.Common.Contracts;
using Experian.Gallery.Application.Common.Dto;
using Experian.Gallery.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Experian.Gallery.Test.ControllerTest
{
    [TestClass]
    public class GalleryControllerTest
    {
        [TestMethod]
        public void GetAlbums_ALL()
        {
            var mockService = new Mock<IGalleryService>();
            mockService.Setup(repo => repo.GetGallery())
                .Returns(Task.FromResult(GetGalleryMock()));

            var controller = new GalleryController(mockService.Object);

            IActionResult result =  controller.GetAlbums().Result;
            var contentResult = result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200,contentResult.StatusCode);
        }


        [TestMethod]
        public void GetAlbums_UserId_OK()
        {
            var mockService = new Mock<IGalleryService>();
            mockService.Setup(repo => repo.GetGallery())
                .Returns(Task.FromResult(GetGalleryMock()));

            var controller = new GalleryController(mockService.Object);

            IActionResult result = controller.GetAlbums(1).Result;
            var contentResult = result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, contentResult.StatusCode);
        }


        [TestMethod]
        public void GetAlbums_UserId_NOTFOUND()
        {
            var mockService = new Mock<IGalleryService>();
            mockService.Setup(repo => repo.GetGallery())
                .Returns(Task.FromResult(GetGalleryMock()));

            var controller = new GalleryController(mockService.Object);

            IActionResult result = controller.GetAlbums(-10).Result;
            var contentResult = result as NotFoundObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, contentResult.StatusCode);
        }


        private IEnumerable<GetAlbumDTO> GetGalleryMock()
        {
            return new GetAlbumDTO[] { new GetAlbumDTO {
                Id = 1,
                UserId = 1,
                Title = "test",
                photos = new GetPhotoDTO[]{ new GetPhotoDTO { Id = 1,AlbumId = 1, Title = "test photo",Url = string.Empty,ThumbnailUrl = string.Empty } }

            } };
        }
    }
}
