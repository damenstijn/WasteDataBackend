using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Commands
{
    public class AddDownloadTestDto
    {
        public long TotalBytesDownloaded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsWifi { get; set; }
        public string ConnectionName { get; set; }
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }
        public int OsId { get; set; }
        public string OsVersion { get; set; }
    }
}
