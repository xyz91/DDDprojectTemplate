using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
    public class HolidayService : BaseService, IHolidayService
    {
        private IMDBHolidayRepository holidayRepository;
        public HolidayService(IMDBHolidayRepository repository){
            this.holidayRepository = repository;
        }
        public HolidayDTO GetBHoliday(string id) => Map<HolidayDTO>(holidayRepository.GetHoliday(id));
    }
}
