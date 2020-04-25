using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;

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
            _wasteDataContext.DownloadTests.Add(new Domain.Entities.DownloadTest 
            {
                CreatedAt = DateTime.Now,
                EndDate = request.DownloadTest.EndDate,
                StartDate = request.DownloadTest.StartDate,
                IsWifi = request.DownloadTest.IsWifi,
                TotalBytesDownloaded = request.DownloadTest.TotalBytesDownloaded
            });

            return Task.FromResult(Unit.Value);
        }
    }
}
