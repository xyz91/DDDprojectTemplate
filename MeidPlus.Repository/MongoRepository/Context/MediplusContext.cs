using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.Context;
using MeidPlus.Repository.MongoRepository.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Context
{
  public  class MediplusContext : MediPlusServer, IMediPlusMongoContext
    {
        public MediplusContext(IConfiguration configuration):base(configuration) {         
        }
        protected override string DataBaseName => "Mediplus";
    }
}
