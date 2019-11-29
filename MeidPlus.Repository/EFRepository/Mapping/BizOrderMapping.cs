using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeidPlus.Repository.EFRepository.Mapping
{
    public class BizOrderMapping : IEntityTypeConfiguration<BizOrder>
    {
        public void Configure(EntityTypeBuilder<BizOrder> builder) {
            builder.ToTable("wf_BizOrder");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("WFOID");
            builder.Property(a => a.Price).HasColumnName("OMTotalPrice");
        }
    }
}
