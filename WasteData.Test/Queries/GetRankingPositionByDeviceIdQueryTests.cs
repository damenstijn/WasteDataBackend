using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MediatR;
using WasteData.Domain.Entities;
using WasteData.Infra.Database;
using Moq;
using WasteData.App.Commands;
using WasteData.Infra.Services.Interfaces;
using WasteData.App.Queries.GetRankingPositionByDeviceId;

namespace WasteData.Test.Queries
{
    public class GetRankingPositionByDeviceIdQueryTests : DownloadTestBase
    {
        [Fact]
        public async void GetRankingPositionByDeviceIdQuery_WhenCalledWithDevice1Guid_ReturnsRanking0()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();

            GetRankingPositionByDeviceIdQuery query = new GetRankingPositionByDeviceIdQuery { DeviceGuid = Guid.Parse(Device1Guid) };
            GetRankingPositionByDeviceIdQueryHandler handler = new GetRankingPositionByDeviceIdQueryHandler(context);

            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            Assert.Equal(0, result.Position);
        }

        [Fact]
        public async void GetRankingPositionByDeviceIdQuery_WhenCalledWithDevice2Guid_ReturnsRanking1()
        {
            using var context = new WasteDataContext(options);
            var mediator = new Mock<IMediator>();

            GetRankingPositionByDeviceIdQuery query = new GetRankingPositionByDeviceIdQuery { DeviceGuid = Guid.Parse(Device2Guid) };
            GetRankingPositionByDeviceIdQueryHandler handler = new GetRankingPositionByDeviceIdQueryHandler(context);

            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            Assert.Equal(1, result.Position);
        }
    }
}
