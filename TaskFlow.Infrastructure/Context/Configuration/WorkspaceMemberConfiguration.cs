using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Infrastructure.Context.Configuration
{
    public class WorkspaceMemberConfiguration : IEntityTypeConfiguration<WorkspaceMember>
    {
        public void Configure(EntityTypeBuilder<WorkspaceMember> builder)
        {
            builder.ToTable("WorkspaceMembers");

            builder.HasKey(wm => wm.Id);

            builder.Property(wm => wm.Role)
                .IsRequired();

            builder.Property(wm => wm.JoinedAt)
                .IsRequired();

            builder.HasIndex(wm => new { wm.WorkspaceId, wm.UserId })
                .IsUnique();
        }
    }
}
