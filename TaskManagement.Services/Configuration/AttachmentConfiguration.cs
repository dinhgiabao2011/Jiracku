﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Configuration
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FileName).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.IsDeleted).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CreatedAt).IsRequired(true);

            builder.HasOne(x => x.Issue).WithMany(x => x.Attachments).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.SubIssue).WithMany(x => x.Attachments).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
