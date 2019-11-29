using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MediPlus.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using MediPlus.Domain.IRepositories.BaseRepository;

namespace MeidPlus.Repository.EFRepository.Base
{
    public abstract class EFUnitOfWork :DbContext, IUnitOfWork
    {
        protected abstract string Constr { get; }
        protected IConfiguration Configuration { get; }
        protected EFUnitOfWork(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder = optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString(Constr));
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableServiceProviderCaching();
        }
        public bool IsCommitted { get; set; }

        public int Commit() {
            return this.SaveChanges();
        }
       
        public void RollBack() { }
    }
}
