using System;
using System.Collections.Generic;
using System.Text;
using MeidPlus.Repository.MongoRepository.Base;
using Microsoft.Extensions.Configuration;

namespace MeidPlus.Repository.MongoRepository.Context
{
    public abstract class MediPlusServer : MongoUnitOfWork
    {
        protected MediPlusServer(IConfiguration configuration) :base (configuration) { }
        protected override string Connstr => "MongoDB";
    }
}
