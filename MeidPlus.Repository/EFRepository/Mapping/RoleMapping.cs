using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MeidPlus.Repository.EFRepository.Mapping
{
   public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roletest");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("SSID");
            builder.Property(a => a.Name).HasColumnName("SStoreName");
            builder.Property(a => a.UserId).HasColumnName("SID");
            builder.HasOne<User>(a => a.User).WithMany(a => a.Roles).HasForeignKey(a=>a.UserId);
        }
    }
}
