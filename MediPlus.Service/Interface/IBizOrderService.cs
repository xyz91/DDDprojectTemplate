using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service.Interface
{
   public interface IBizOrderService : IBaseService<BizOrder, int, BizOrderDTO>
    {
    }
}
