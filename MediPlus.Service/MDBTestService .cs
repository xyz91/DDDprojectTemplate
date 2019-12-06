using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
    public class MDBTestService : BaseService<MDBTest,int,MDBTestDTO>, IMDBTestService
    {
        private IMDBTestRepository  repository;
        public MDBTestService(IMDBTestRepository repository):base(repository){
        }
    }
}
