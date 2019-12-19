using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
   internal class MediTest2Service   : BaseUnitService<MediTest, string, MediTestDTO>, IMediTest2Service
    {
        private new IMediTestEF2Repository repository;
        public MediTest2Service(IMediTestEF2Repository repository):base(repository) {
            this.repository = repository;
        }
    }
}
