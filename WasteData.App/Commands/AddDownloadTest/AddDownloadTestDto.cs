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
    }
}
