using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.Domain.Entities
{
    public class DownloadTest
    {
        private DownloadTest() { }

        public DownloadTest(long totalBytesDownloaded, DateTime startDate, DateTime endDate, bool isWifi, string connectionName, string ipAddress, string country)
        {
            TotalBytesDownloaded = totalBytesDownloaded;
            StartDate = startDate;
            EndDate = endDate;
            IsWifi = isWifi;
            ConnectionName = connectionName;
            IpAddress = ipAddress;
            Country = country;

            CreatedAt = DateTime.Now;
        }

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
