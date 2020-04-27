using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.Domain.Entities;

namespace WasteData.Infra.Database
{
    public class WasteDataContext : DbContext
    {
        public DbSet<DownloadTest> DownloadTests { get; set; }
        public DbSet<Device> Devices { get; set; }

        public WasteDataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WasteDataContext).Assembly);
        }
    }
}
