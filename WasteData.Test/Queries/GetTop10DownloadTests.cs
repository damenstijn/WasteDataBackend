using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MediatR;
using WasteData.Infra.Database;
using Moq;
using WasteData.App.Queries.GetTop10DownloadTests;

namespace WasteData.Test.Queries
{
    public class GetTop10DownloadTests : DownloadTestBase
    {
        [Fact]
        public void GetTop10DownloadTests_WhenCalled_ReturnsDevice1OnFirstPlace()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();
            var sqlConnectionFactory = new Mock<ISqlConnectionFactory>();

            GetTop10DownloadTestsQuery query = new GetTop10DownloadTestsQuery();
            //GetTop10DownloadTestsQueryHandler handler = new GetTop10DownloadTestsQueryHandler(sqlConnectionFactory.Object);

            //var result = handler.Handle(query, new System.Threading.CancellationToken()).Result;

            //Assert.Equal(0, result.Position);
        }
    }
}
