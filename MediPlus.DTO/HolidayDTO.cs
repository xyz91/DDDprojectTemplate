﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
namespace MediPlus.DTO
{
   public class HolidayDTO : EntityDTO<string>
    {
        public int Year { get; set; }
        public string Holidays { get; set; }
    }
}
