using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.DTO;

namespace MediPlus.Service.Interface
{
   public interface IHolidayService
    {
        HolidayDTO GetBHoliday(string id);
    }
}
