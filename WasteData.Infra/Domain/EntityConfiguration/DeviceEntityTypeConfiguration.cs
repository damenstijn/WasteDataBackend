using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.Domain.Entities;

namespace WasteData.Infra.Domain
{
    internal class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Device", "dbo");

            builder.HasKey(b => b.DeviceId);

            builder.Property(p => p.DeviceGuid).HasColumnName("DeviceGuid").IsRequired();
            builder.Property(p => p.DeviceName).HasColumnName("DeviceName").IsRequired().HasMaxLength(1000);
            builder.Property(p => p.OsId).HasColumnName("OsId").IsRequired();
            builder.Property(p => p.OsVersion).HasColumnName("OsVersion").IsRequired().HasMaxLength(1000);

            builder.HasIndex(p => p.DeviceGuid);

            builder.HasMany(p => p.DownloadTests).WithOne(p => p.Device).IsRequired();

            builder.Metadata
                .FindNavigation(nameof(Device.DownloadTests))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
