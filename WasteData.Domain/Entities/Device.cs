using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace WasteData.Domain.Entities
{
    public class Device
    {
        private Device()
        {
            _downloadTests = new List<DownloadTest>();
        }

        public Device(Guid deviceGuid, string deviceName, int osId, string osVersion)
        {
            DeviceGuid = deviceGuid;
            DeviceName = deviceName;
            OsId = osId;
            OsVersion = osVersion;
            _downloadTests = new List<DownloadTest>();
        }

        public int DeviceId { get; set; }
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }
        public int OsId { get; set; }
        public string OsVersion { get; set; }

        private readonly List<DownloadTest> _downloadTests;
        public IReadOnlyCollection<DownloadTest> DownloadTests => _downloadTests;

        public void AddDownloadTest(DownloadTest downloadTest) 
        {
            if (downloadTest != null)
            {
                _downloadTests.Add(downloadTest);
            }
            else 
            {
                throw new ArgumentNullException("Param DownloadTest is null");
            }
        }
    }
}
