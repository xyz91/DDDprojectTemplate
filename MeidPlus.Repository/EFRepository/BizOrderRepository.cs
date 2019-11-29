using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MeidPlus.Repository.EFRepository;
using MeidPlus.Repository.EFRepository.Base;
using MeidPlus.Repository.EFRepository.Context;

namespace MeidPlus.Repository.EFRepository
{
  public  class BizOrderRepository: EFBaseRepository<BizOrder, int>, IBizOrderRepository
    {
        public BizOrderRepository(MediPlus2Context context):base(context) { 
        
        }
    }
}
