using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WasteData.Infra.Database;
using System.Linq;
using Dapper;

namespace WasteData.App.Queries.GetTop10DownloadTests
{
    internal class GetTop10DownloadTestsQueryHandler : IRequestHandler<GetTop10DownloadTestsQuery, List<GetTop10DownloadTestsDto>>
    {
        private readonly WasteDataContext _wasteDataContext;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetTop10DownloadTestsQueryHandler(WasteDataContext wasteDataContext, ISqlConnectionFactory sqlConnectionFactory)
        {
            _wasteDataContext = wasteDataContext;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<GetTop10DownloadTestsDto>> Handle(GetTop10DownloadTestsQuery request, CancellationToken cancellationToken)
        {
            const string sql =  "SELECT " +
                                "d.[DeviceId], " +
                                "SUM(dt.[TotalBytesDownloaded]) AS [TotalBytesDownloaded], " +
                                "MAX(d.DeviceName) AS [DeviceName], " +
                                "MAX(d.DeviceGuid) AS [DeviceGuid], " +
                                "MAX(dt.Country) AS [Country], " +
                                "MAX(d.OsId) AS [OsIs] " +
                                "FROM [DownloadTest] dt " +
                                "INNER JOIN [Device] d ON d.[DeviceId] = dt.[DeviceId] " +
                                "GROUP BY d.[DeviceId]";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            var result = await connection.QueryAsync<GetTop10DownloadTestsDto>(sql);

            return result.ToList();
        }
    }
}
