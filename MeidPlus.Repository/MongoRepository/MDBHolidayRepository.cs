﻿using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using MeidPlus.Repository.MongoRepository.Base;
using MeidPlus.Repository.MongoRepository.Context;

namespace MeidPlus.Repository.MongoRepository
{
  public  class MDBHolidayRepository : MongoBaseRepository<MDBYearHoliday,ObjectId>, IMDBHolidayRepository
    {
        public MDBHolidayRepository(MediplusContext unitOfWork):base(unitOfWork) {
           
        }

        public MDBYearHoliday GetMDBYearHoliday(ObjectId id)
        {

          return  Entities.SingleOrDefault(a => a.Id == id);
        }
        public MDBYearHoliday GetHoliday(string id) {
            return GetById(ObjectId.Parse(id));
        }
    }
}