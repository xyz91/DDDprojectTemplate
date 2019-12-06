using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
   public class MDBYearHoliday : AggregateRoot<string>
    {
        public MDBYearHoliday(string id):base(id) { }
        public MDBYearHoliday(string id,int year,string holidays):this(id) {
            //this.Year = year;
            this.Holidays = holidays;
        }
        //public int Year { get; set; }
        public string Holidays { get; set; }
    }
}
