using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediPlus.Domain.Model
{
    [BsonIgnoreExtraElements]
   public class MDBYearHoliday : AggregateRoot<ObjectId>
    {
        public MDBYearHoliday(ObjectId id):base(id) { }
        public MDBYearHoliday(ObjectId id,int year,string holidays):this(id) {
            this.Year = year;
            this.Holidays = holidays;
        }
        public int Year { get; set; }
        public string Holidays { get; set; }
    }
}
