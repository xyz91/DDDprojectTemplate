using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
    public class HolidayService : BaseUnitService<MDBYearHoliday, string,HolidayDTO>, IHolidayService
    {
        private IMDBHolidayRepository holidayRepository;
        public HolidayService(IMDBHolidayRepository repository):base(repository){
        }
    }
}
