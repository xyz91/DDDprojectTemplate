using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
namespace MediPlus.Domain.IRepositories
{
   public interface IBizOrderRepository : IRepository<BizOrder, int>
    {
    }
}
