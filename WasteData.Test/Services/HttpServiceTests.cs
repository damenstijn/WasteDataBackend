using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.App.Interfaces;
using WasteData.Infra.Services;
using Xunit;

namespace WasteData.Test.Services
{
    public class HttpServiceTests
    {
        public HttpServiceTests()
        {
        }

        [Fact]
        public async void HttpService_GetCountryByIpAddress_ReturnsCountry()
        {
            var logger = new Mock<ILogger<IHttpService>>();
            var httpService = new HttpService(logger.Object);

            var result = await httpService.GetCountryByIpAddress("94.111.111.59");

            Assert.Equal("BE", result);
        }
    }
}
