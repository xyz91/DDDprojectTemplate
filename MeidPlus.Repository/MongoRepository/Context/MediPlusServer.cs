using System;
using System.Collections.Generic;
using System.Text;
using MeidPlus.Repository.MongoRepository.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Context
{
    public abstract class MediPlusServer : MongoUnitOfWork
    {
        private static MongoClient client = null;
        
        protected MediPlusServer(IConfiguration configuration) :base (configuration,ref client) {
        }
        protected override string Connstr => "MongoDB";
    }
}
