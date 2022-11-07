using Experian.Gallery.Application.Common.Contracts;
using Experian.Gallery.Application.Common.Dto;
using Experian.Gallery.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Experian.Gallery.Infrastructure.Configuration;
using System.Linq;

namespace Experian.Gallery.Test.ServiceTest
{
    [TestClass]
    public class GalleryServiceTest
    {
        [TestMethod]
        public void GetGallery()
        {

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json");
            var Configuration = builder.Build();

            var mockLogger = new Mock<ILogger<GalleryService>>();

            var cache = new MemoryCache(new MemoryCacheOptions());

            var service = new GalleryService(mockLogger.Object, Configuration, cache);

            var result = service.GetGallery().Result;           

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0,result.ToList().Count());
        }


    }
}
