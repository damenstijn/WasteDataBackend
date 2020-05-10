using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WasteData.Domain.Entities;

namespace WasteData.App.Interfaces
{
    public interface IWasteDataContext
    {
        DbSet<DownloadTest> DownloadTests { get; set; }
        DbSet<Device> Devices { get; set; }

        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Add(object entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
