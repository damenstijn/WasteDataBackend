using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WasteData.App.Commands
{
    internal class AddDownloadTestCommandHandler : IRequestHandler<AddDownloadTestCommand>
    {
        private readonly WasteDataContext _wasteDataContext;

        public AddDownloadTestCommandHandler(WasteDataContext wasteDataContext)
        {
            _wasteDataContext = wasteDataContext;
        }

        public Task<Unit> Handle(AddDownloadTestCommand request, CancellationToken cancellationToken)
        {
            var device = _wasteDataContext.Devices.SingleOrDefault(p => p.DeviceGuid == request.DownloadTest.DeviceGuid);

            if (device == null) 
            {
                device = new Domain.Entities.Device
                {
                    DeviceGuid = request.DownloadTest.DeviceGuid,
                    DeviceName = request.DownloadTest.DeviceName,
                    OsId = request.DownloadTest.OsId,
                    OsVersion = request.DownloadTest.OsVersion
                };

                _wasteDataContext.Devices.Add(device);
                _wasteDataContext.SaveChanges();
            }


            _wasteDataContext.DownloadTests.Add(new Domain.Entities.DownloadTest 
            {
                CreatedAt = DateTime.Now,
                EndDate = request.DownloadTest.EndDate,
                StartDate = request.DownloadTest.StartDate,
                IsWifi = request.DownloadTest.IsWifi,
                TotalBytesDownloaded = request.DownloadTest.TotalBytesDownloaded,
                ConnectionName = request.DownloadTest.ConnectionName,
                Country = request.DownloadTest.Country,
                IpAddress = request.DownloadTest.IpAddress,
                Device = device
            });

            _wasteDataContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
