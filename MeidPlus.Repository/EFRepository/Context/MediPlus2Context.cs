using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.Context;
using MeidPlus.Repository.EFRepository.Base;
using MeidPlus.Repository.EFRepository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MeidPlus.Repository.EFRepository.Context
{
    public class MediPlus2Context : EFUnitOfWork, IMediPlus2Context
    {
        public MediPlus2Context(IConfiguration configuration) :base(configuration) { 
        }
        protected override string Constr => "con2";
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BizOrderMapping());
        }
    }
}
