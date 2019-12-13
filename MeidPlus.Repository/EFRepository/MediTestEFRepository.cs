using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Context;
using MediPlus.Domain.Model;
using MeidPlus.Repository.EFRepository;
using MeidPlus.Repository.EFRepository.Base;
using MeidPlus.Repository.EFRepository.Context;

namespace MeidPlus.Repository.EFRepository
{
  public  class MediTestEFRepository: EFBaseRepository<MediTest, string>, IMediTestEFRepository
    {
        public MediTestEFRepository(IMediPlusContext context):base(context) { 
        
        }
    }
}
