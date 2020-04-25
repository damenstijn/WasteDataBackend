using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WasteData.App.Queries.GetTop10DownloadTests
{
    internal class GetTop10DownloadTestsQueryHandler : IRequestHandler<GetTop10DownloadTestsQuery, List<DownloadTestDto>>
    {
        private readonly WasteDataContext _wasteDataContext;

        public GetTop10DownloadTestsQueryHandler(WasteDataContext wasteDataContext)
        {
            _wasteDataContext = wasteDataContext;
        }

        public async Task<List<DownloadTestDto>> Handle(GetTop10DownloadTestsQuery request, CancellationToken cancellationToken)
        {
            return await _wasteDataContext.DownloadTests.AsNoTracking()
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.TotalBytesDownloaded)
                .Take(10)
                .Select(k => new DownloadTestDto 
                { 
                    DownloadTestId = k.DownloadTestId, 
                    EndDate = k.EndDate, 
                    IsWifi = k.IsWifi, 
                    StartDate = k.StartDate, 
                    TotalBytesDownloaded = k.TotalBytesDownloaded,
                    Username = "stijn"
                })
                .ToListAsync();
        }
    }
}
