using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
namespace MediPlus.Domain.IRepositories
{
  public  interface IMDBHolidayRepository  : IRepository<MDBYearHoliday, string> , IMongoRepository<MDBYearHoliday, string>
    {
        MDBYearHoliday GetHoliday(string id);
    }
}
