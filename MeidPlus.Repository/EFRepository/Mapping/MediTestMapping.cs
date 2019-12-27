using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeidPlus.Repository.EFRepository.Mapping
{
    public class MediTestMapping : IEntityTypeConfiguration<MediTest>
    {
        public void Configure(EntityTypeBuilder<MediTest> builder) {
            builder.ToTable("MediTest").HasKey(a=>a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnName("testname");
            builder.HasMany(a => a.MediTestNodes).WithOne(a => a.MediTest).HasForeignKey(a=>a.MediTestId);
            builder.Ignore("LazyLoader");
        }
    }
}
