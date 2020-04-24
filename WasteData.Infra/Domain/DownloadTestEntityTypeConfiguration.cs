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

            builder.Property("TotalBytesDownloaded").HasColumnName("TotalBytesDownloaded").IsRequired();
            builder.Property("StartDate").HasColumnName("StartDate").IsRequired();
            builder.Property("EndDate").HasColumnName("EndDate").IsRequired();
            builder.Property("IsWifi").HasColumnName("IsWifi").IsRequired();
            builder.Property("CreatedAt").HasColumnName("CreatedAt").IsRequired();
            builder.Property("IsDeleted").HasColumnName("IsDeleted").IsRequired();
        }
    }
}
