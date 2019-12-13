using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using System.Linq;
namespace MediPlus.Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<BizOrder, BizOrderDTO>().ReverseMap();
            //CreateMap<MDBYearHoliday, HolidayDTO>().ReverseMap();
            //CreateMap<MDBTest, MDBTestDTO>().ReverseMap();

            var types = typeof(MapperProfile).Assembly.GetTypes().Where(a => a.BaseType != null && a.BaseType.IsGenericType && a.BaseType.GetGenericTypeDefinition() == typeof(BaseUnitService<,,>)).ToList();
            foreach (var item in types)
            {
                var arg = item.BaseType.GetGenericArguments();
                CreateMap(arg[0], arg[2]).ReverseMap();
            }

            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<ChildNode, ChildNodeDTO>().ReverseMap();

        }
    }
}
