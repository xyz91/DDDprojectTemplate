﻿using System;
using System.Collections.Generic;
using System.Text;
using MeidPlus.Repository.EFRepository.Base;
using MeidPlus.Repository.EFRepository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MeidPlus.Repository.EFRepository.Context
{
   public class MediPlusContext: EFUnitOfWork 
    {
        public MediPlusContext(IConfiguration configuration) : base(configuration)
        {
        }
        protected override string Constr => "con";
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MediTestMapping());
            modelBuilder.ApplyConfiguration(new MediTestNodeMapping());
        }
    }
}
