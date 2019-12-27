using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MeidPlus.Repository.EFRepository.Mapping
{
   public class MediTestNodeMapping : IEntityTypeConfiguration<MediTestNode>
    {
        public void Configure(EntityTypeBuilder<MediTestNode> builder)
        {
            builder.ToTable("MeditTestNode").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnName("nodename");
            builder.Property(a => a.MediTestId).HasColumnName("MediTestId");
            builder.Ignore(a => a.Age);
        }
    }
}
