using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Queries.GetTop10DownloadTests
{
    public class GetTop10DownloadTestsDto
    {
        public int DeviceId { get; set; }
        public long TotalBytesDownloaded { get; set; }
        public string DeviceName { get; set; }
        public Guid DeviceGuid { get; set; }
        public string Country { get; set; }
        public int OsId { get; set; }
    }
}
