﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Order).IsRequired(false);
            builder.Property(x => x.UserId).IsRequired(false);
            builder.Property(x => x.IsDeleted).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CreatedAt).IsRequired(true);

            builder.HasOne(x => x.Column).WithMany(x => x.Notes).HasForeignKey(x => x.ColumnId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
