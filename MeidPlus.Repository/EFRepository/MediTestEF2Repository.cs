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
   public class MediTestEF2Repository : EFBaseRepository<MediTest, string>, IMediTestEF2Repository
    {
        
        public MediTestEF2Repository(IMediPlus2Context unitOfWork):base(unitOfWork) {
                                                
        }
    }
}
