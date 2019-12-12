using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace MediPlus.Utility
{
    public  class ServiceLocator
    {
        public static IServiceProvider Provider { get; set; }
        public static ILifetimeScope Container { get; set; }
        public static Dictionary<Type, Type> EventTypes { get; set; } = new Dictionary<Type, Type>();
       
        
    }
}
