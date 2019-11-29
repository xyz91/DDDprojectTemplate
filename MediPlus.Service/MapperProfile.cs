using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<BizOrder, BizOrderDTO>().ReverseMap();
            CreateMap<MDBYearHoliday, HolidayDTO>().ReverseMap();
        }
    }
}
