using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using MeidPlus.Repository.MongoRepository.Base;
using MeidPlus.Repository.MongoRepository.Context;

namespace MeidPlus.Repository.MongoRepository
{
  internal  class MediTestMongoRepository : MongoBaseRepository<MediTest, string>, IMediTestMongoRepository
    {
        public MediTestMongoRepository(MediplusContext unitOfWork):base(unitOfWork) {
           
        }
    }
}
