using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.Domain.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }
        public int OsId { get; set; }
        public string OsVersion { get; set; }
        public ICollection<DownloadTest> DownloadTests { get; set; }
    }
}
