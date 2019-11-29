using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MongoDB.Bson;
namespace MediPlus.Domain.IRepositories
{
  public  interface IMDBHolidayRepository  : IRepository<MDBYearHoliday, ObjectId>
    {
        MDBYearHoliday GetHoliday(string id);
    }
}
