using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.Infra.Services;
using WasteData.Infra.Services.Interfaces;
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
            var logger = new Mock<ILogger<HttpService>>();
            var httpService = new HttpService(logger.Object);

            var result = await httpService.GetCountryByIpAddress("94.111.111.59");

            Assert.Equal("BE", result);
        }
    }
}
