using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
   public class MediTestMongoService   : BaseUnitService<MediTest, string, MediTestDTO>, IMediTestMongoService
    {
        private new IMediTestMongoRepository repository;
        public MediTestMongoService(IMediTestMongoRepository repository):base(repository) {
            this.repository = repository;
        }
    }
}
