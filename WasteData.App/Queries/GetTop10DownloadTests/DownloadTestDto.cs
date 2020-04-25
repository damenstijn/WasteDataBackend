using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Queries.GetTop10DownloadTests
{
    public class DownloadTestDto
    {
        public int DownloadTestId { get; set; }
        public long TotalBytesDownloaded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsWifi { get; set; }
        public string Username { get; set; }
    }
}
