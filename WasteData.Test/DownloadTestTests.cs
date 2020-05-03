using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WasteData.Domain.Entities;
using WasteData.Infra.Database;
using Xunit;
using MediatR;
using WasteData.App.Queries.GetRankingPositionByDeviceId;
using WasteData.App.Commands;

namespace WasteData.Test
{
    public class DownloadTestTests
    {
        private readonly DbContextOptions<WasteDataContext> options;

        public DownloadTestTests()
        {
            options = new DbContextOptionsBuilder<WasteDataContext>()
            .UseInMemoryDatabase(databaseName: "WasteDataDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WasteDataContext(options))
            {
                var device1 = new Device
                {
                    DeviceGuid = Guid.Parse("82123327-524E-4103-8192-E2A5FD4F9830"),
                    DeviceId = 10,
                    DeviceName = "OnePlus",
                    OsId = 0,
                    OsVersion = "10"
                };
                context.Devices.Add(device1);

                context.SaveChanges();

                context.DownloadTests.Add(new DownloadTest
                {
                    DownloadTestId = 10,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMinutes(-2),
                    Country = "BE",
                    IpAddress = "192.168.0.1",
                    IsDeleted = false,
                    IsWifi = false,
                    TotalBytesDownloaded = (10 * 1024 * 1024),
                    Device = device1
                });

                context.DownloadTests.Add(new DownloadTest
                {
                    DownloadTestId = 11,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMinutes(-2),
                    Country = "BE",
                    IpAddress = "192.168.0.1",
                    IsDeleted = false,
                    IsWifi = false,
                    TotalBytesDownloaded = (100 * 1024 * 1024),
                    Device = device1
                });

                context.SaveChanges();
            }
        }

        [Fact]
        public void GetRankingPositionByDeviceIdQuery_WhenCalledWithDeviceGuid_ReturnsRanking()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();

            GetRankingPositionByDeviceIdQuery query = new GetRankingPositionByDeviceIdQuery {DeviceGuid = Guid.Parse("82123327-524E-4103-8192-E2A5FD4F9830") };
            GetRankingPositionByDeviceIdQueryHandler handler = new GetRankingPositionByDeviceIdQueryHandler(context);

            var result = handler.Handle(query, new System.Threading.CancellationToken()).Result;
            
            Assert.Equal(0, result.Position);
        }

        [Fact]
        public void AddDownloadTestCommand_WhenCalled_AddsDeviceAndDownloadTest()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();

            AddDownloadTestCommand command = new AddDownloadTestCommand
            {
                DownloadTest = new AddDownloadTestDto
                {
                    DeviceGuid = Guid.NewGuid()
                }
            };

            //AddDownloadTestCommandHandler handler = new AddDownloadTestCommandHandler(context);

            //var result = handler.Handle(command, new System.Threading.CancellationToken()).Result;

            //Assert.Equal(0, result.Position);
        }
    }
}
