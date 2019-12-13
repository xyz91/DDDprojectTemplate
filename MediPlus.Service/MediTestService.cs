using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
   public class MediTestService   : BaseUnitService<MediTest, string, MediTestDTO>, IMediTestService
    {
        private new IMediTestEFRepository repository;
        public MediTestService(IMediTestEFRepository repository):base(repository) {
            this.repository = repository;
        }
    }
}
