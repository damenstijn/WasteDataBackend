using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Queries.GetRankingPositionByDeviceId
{
    public class GetRankingPositionByDeviceIdQuery : IRequest<GetRankingPositionByDeviceIdDto>
    {
        public Guid DeviceGuid { get; set; }
    }
}
