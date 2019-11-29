using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeidPlus.Repository.EFRepository.Mapping
{
   public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("db_Supplier");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("SID");
            builder.Property(a => a.Name).HasColumnName("SName");
            builder.HasMany<Role>(a => a.Roles).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}
