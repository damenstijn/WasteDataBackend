using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.Domain.Entities;

namespace WasteData.Infra.Domain
{
    internal class DownloadTestEntityTypeConfiguration : IEntityTypeConfiguration<DownloadTest>
    {
        public void Configure(EntityTypeBuilder<DownloadTest> builder)
        {
            builder.ToTable("DownloadTest", "dbo");

            builder.HasKey(b => b.DownloadTestId);

            builder.Property(p => p.TotalBytesDownloaded).HasColumnName("TotalBytesDownloaded").IsRequired();
            builder.Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
            builder.Property(p => p.IsWifi).HasColumnName("IsWifi").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("IsDeleted").IsRequired();
            builder.Property(p => p.ConnectionName).HasColumnName("ConnectionName").IsRequired();
            builder.Property(p => p.IpAddress).HasColumnName("IpAddress").IsRequired();
            builder.Property(p => p.Country).HasColumnName("Country").IsRequired();

            builder.HasIndex(p => p.TotalBytesDownloaded);
        }
    }
}
