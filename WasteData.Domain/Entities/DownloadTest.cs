using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.Domain.Entities
{
    public class DownloadTest
    {
        public int DownloadTestId { get; set; }
        public long TotalBytesDownloaded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsWifi { get; set; }
        public string ConnectionName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public Device Device { get; set; }
    }
}
