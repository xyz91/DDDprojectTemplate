using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using System.Linq;
using MediPlus.Utility;

namespace MediPlus.Service
{
    public class MapperProfile : Profile
    {
        /// <summary>
        /// dto到model映射
        /// </summary>
        public MapperProfile()
        {
            var types = typeof(MapperProfile).Assembly.GetTypes().Where(a => a.BaseType != null && a.BaseType.IsGenericType && a.BaseType.GetGenericTypeDefinition() == typeof(BaseUnitService<,,>)).ToList();
            foreach (var item in types)
            {
                var arg = item.BaseType.GetGenericArguments();
                CreateMap(arg[0], arg[2]).ReverseMap();
            }
            CreateMap<MediTest, MediTestDTO>().ForMember(a => a.MediTestNodes, b => b.MapFrom(c => c.MediTestNodes)).ReverseMap();
            CreateMap<MediTestNode, MediTestNodeDTO>().ReverseMap();
            CreateMap(typeof(PagingObject<>), typeof(PagingDTO<>));
        }
    }
}