using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WasteData.Infra.Services.Interfaces;

namespace WasteData.App.Commands
{
    public class AddDownloadTestCommandHandler : IRequestHandler<AddDownloadTestCommand>
    {
        private readonly WasteDataContext _wasteDataContext;
        private readonly IHttpService _httpService;

        public AddDownloadTestCommandHandler(WasteDataContext wasteDataContext, IHttpService httpService)
        {
            _wasteDataContext = wasteDataContext;
            _httpService = httpService;
        }

        public Task<Unit> Handle(AddDownloadTestCommand request, CancellationToken cancellationToken)
        {
            var device = _wasteDataContext.Devices.SingleOrDefault(p => p.DeviceGuid == request.DownloadTest.DeviceGuid);

            if (device == null) 
            {
                device = new Domain.Entities.Device(
                    request.DownloadTest.DeviceGuid, 
                    request.DownloadTest.DeviceName, 
                    request.DownloadTest.OsId, 
                    request.DownloadTest.OsVersion);

                _wasteDataContext.Add(device);
                _wasteDataContext.SaveChanges();
            }


            var country = _httpService.GetCountryByIpAddress(request.DownloadTest.IpAddress).Result;

            var downloadTest = new Domain.Entities.DownloadTest(
                request.DownloadTest.TotalBytesDownloaded, 
                request.DownloadTest.StartDate, 
                request.DownloadTest.EndDate, 
                request.DownloadTest.IsWifi, 
                request.DownloadTest.ConnectionName, 
                request.DownloadTest.IpAddress, 
                country);


            device.AddDownloadTest(downloadTest);

            _wasteDataContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
