using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public class BizOrderDTO:EntityDTO<int>
    {
        public decimal Price { get; set; }
    }
}
