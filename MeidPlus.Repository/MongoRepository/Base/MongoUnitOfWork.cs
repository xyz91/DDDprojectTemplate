﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.BaseRepository;
using MeidPlus.Repository.MongoRepository.Mapping;
using Microsoft.Extensions.Configuration;

namespace MeidPlus.Repository.MongoRepository.Base
{
    public abstract class MongoUnitOfWork: MongoContext, IUnitOfWork 
    {
        public bool IsCommitted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected MongoUnitOfWork(IConfiguration configuration):base(configuration) { 
        
        }
        protected abstract override string DataBaseName { get; }

        public int Commit() => throw new NotImplementedException();
        public void RollBack() => throw new NotImplementedException();
        public Task<int> CommitAsync() => throw new NotImplementedException();

        static MongoUnitOfWork() {
            MongodbMapping.Register();
        }

    }
}
