﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Configuration
{
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.ToTable("UserProject");
            builder.HasKey(x => new { x.ProjectId, x.UserId });
            builder.HasOne(x => x.Project).WithMany(x => x.UserProjects).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.JoinDate).IsRequired(true);
        }
    }
}
