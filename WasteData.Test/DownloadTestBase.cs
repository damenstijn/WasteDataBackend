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

namespace WasteData.Test
{
    public abstract class DownloadTestBase : IDisposable
    {
        protected DbContextOptions<WasteDataContext> options;
        private static int counter = 0;

        protected const string Device1Guid = "82123327-524E-4103-8192-E2A5FD4F9830";
        protected const string Device2Guid = "82123327-524E-4103-8192-E2A5FD4F9831";

        public DownloadTestBase()
        {
            options = new DbContextOptionsBuilder<WasteDataContext>()
            .UseInMemoryDatabase(databaseName: "WasteDataDatabase" + counter++)
            .Options;

            // Insert seed data into the database using one instance of the context
            using var context = new WasteDataContext(options);


            var device1 = new Device(Guid.Parse(Device1Guid), "OnePlus", 0, "10");
            var device2 = new Device(Guid.Parse(Device1Guid), "OnePlus", 0, "10");

            context.Devices.Add(device1);
            context.Devices.Add(device2);

            context.SaveChanges();

            for (int i = 0; i < 5; i++)
            {
                var totalBytesDownloaded = ((20 + i) * 1024 * 1024);
                var downloadTest = new DownloadTest(totalBytesDownloaded, DateTime.Now.AddMinutes(i), DateTime.Now.AddMinutes(i - 2), false, "", "192.168.0.123", "BE");
                device1.AddDownloadTest(downloadTest);
            }

            for (int i = 0; i < 5; i++)
            {
                var totalBytesDownloaded = ((10 + i) * 1024 * 1024);
                var downloadTest = new DownloadTest(totalBytesDownloaded, DateTime.Now.AddMinutes(i), DateTime.Now.AddMinutes(i - 2), false, "", "192.168.0.123", "BE");
                device1.AddDownloadTest(downloadTest);
            }

            context.SaveChanges();
        }

        public void Dispose() 
        {
            
        }
    }
}
