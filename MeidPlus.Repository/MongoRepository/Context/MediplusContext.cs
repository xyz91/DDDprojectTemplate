using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Context
{
  public  class MediplusContext : MediPlusServer
    {
        public MediplusContext(IConfiguration configuration):base(configuration) {         
        }
        protected override string DataBaseName => "Mediplus";

    }
}
