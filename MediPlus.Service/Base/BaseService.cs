using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Service.Base;
namespace MediPlus.Service
{
   public class BaseService
    {
        private IMapper Mapper { get; set; }= (IMapper)ServiceLocator.Provider.GetService(typeof(IMapper));       
        protected T Map<T>(object obj) where T:class 
        {           
            return Mapper?.Map<T>(obj);
        }
    }
}
