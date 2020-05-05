using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MediatR;
using WasteData.Domain.Entities;
using WasteData.Infra.Database;
using Moq;
using WasteData.App.Commands;
using WasteData.App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WasteData.Test.Commands
{
    public class AddDownloadTestCommandTests : DownloadTestBase
    {
        [Fact]
        public async void AddDownloadTestCommand_WhenCalled_AddsDeviceAndDownloadTest()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();
            var httpService = new Mock<IHttpService>();

            var newDeviceGuid = Guid.NewGuid();
            var totalBytes = 100 * 1024 * 1024;

            AddDownloadTestCommand command = new AddDownloadTestCommand
            {
                DownloadTest = new AddDownloadTestDto
                {
                    DeviceGuid = newDeviceGuid,
                    DeviceName = "TestName1",
                    ConnectionName = "OurWifi",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMinutes(-2),
                    IpAddress = "94.111.111.59",
                    IsWifi = false,
                    OsId = 0,
                    OsVersion = "10",
                    TotalBytesDownloaded = totalBytes
                }
            };

            httpService.Setup(p => p.GetCountryByIpAddress("94.111.111.59")).ReturnsAsync("BE");

            AddDownloadTestCommandHandler addDownloadTestCommandHandler = new AddDownloadTestCommandHandler(context, httpService.Object);

            await addDownloadTestCommandHandler.Handle(command, new System.Threading.CancellationToken());

            var device = context.Devices.Include(p => p.DownloadTests).SingleOrDefault(p => p.DeviceGuid == newDeviceGuid);

            Assert.NotNull(device);

            Assert.Collection(device.DownloadTests, item => Assert.Equal(totalBytes, item.TotalBytesDownloaded));
        }
    }
}
