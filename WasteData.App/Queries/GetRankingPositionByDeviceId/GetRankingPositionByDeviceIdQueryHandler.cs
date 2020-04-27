using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WasteData.App.Queries.GetRankingPositionByDeviceId
{
    internal class GetRankingPositionByDeviceIdQueryHandler : IRequestHandler<GetRankingPositionByDeviceIdQuery, GetRankingPositionByDeviceIdDto>
    {
        private readonly WasteDataContext _wasteDataContext;

        public GetRankingPositionByDeviceIdQueryHandler(WasteDataContext wasteDataContext)
        {
            _wasteDataContext = wasteDataContext;
        }

        public async Task<GetRankingPositionByDeviceIdDto> Handle(GetRankingPositionByDeviceIdQuery request, CancellationToken cancellationToken)
        {
            var bytesForDeviceGuid = await _wasteDataContext.DownloadTests.AsNoTracking()
                .Where(p => !p.IsDeleted && p.Device.DeviceGuid == request.DeviceGuid)
                .GroupBy(p => p.Device.DeviceGuid)
                .Select(p => p.Sum(o => o.TotalBytesDownloaded))
                .FirstOrDefaultAsync(cancellationToken);


            var amountOfDevicesRankBeforeDevice = await _wasteDataContext.DownloadTests.AsNoTracking()
                .Where(p => !p.IsDeleted)
                .GroupBy(p => p.Device.DeviceGuid)
                .Select(p => new 
                { 
                    Device = p.Key,
                    TotalBytes = p.Sum(o => o.TotalBytesDownloaded)
                })
                .OrderByDescending(p => p.TotalBytes)
                .Where(p => p.TotalBytes > bytesForDeviceGuid)
                .CountAsync(cancellationToken);

            return new GetRankingPositionByDeviceIdDto
            {
                Position = amountOfDevicesRankBeforeDevice
            };
        }
    }
}
