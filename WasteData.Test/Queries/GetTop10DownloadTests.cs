using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MediatR;
using WasteData.Infra.Database;
using Moq;
using WasteData.App.Queries.GetTop10DownloadTests;
using WasteData.App.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace WasteData.Test.Queries
{
    public class GetTop10DownloadTests : DownloadTestBase
    {
        [Fact]
        public void GetTop10DownloadTests_WhenCalled_ReturnsDevice1OnFirstPlace()
        {
            var expectedPositionDevice = Device1Guid;

            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();
            var sqlConnectionFactory = new Mock<ISqlConnectionFactory>();

            GetTop10DownloadTestsQuery query = new GetTop10DownloadTestsQuery();
            GetTop10DownloadTestsQueryHandler handler = new GetTop10DownloadTestsQueryHandler(sqlConnectionFactory.Object);

            //TODO how to test Dapper query

            //var result = handler.Handle(query, new System.Threading.CancellationToken()).Result;

            //var listOrderedByTotalBytesDownloadedDesc = result.OrderByDescending(p => p.TotalBytesDownloaded);

            //var deviceFirstPosition = listOrderedByTotalBytesDownloadedDesc.First();

            //Assert.Equal(expectedPositionDevice, deviceFirstPosition.DeviceGuid.ToString());
        }
    }
}
