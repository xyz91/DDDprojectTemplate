using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.Service.Interface;
using MediPlus.Domain.IRepositories;
using AutoMapper;
using MediPlus.Service.Base;
using MediPlus.DTO;

namespace MediPlus.Service
{
    public class BizOrderService : BaseService,IBizOrderService
    {
        private IBizOrderRepository bizOrderRepository;
        
        public BizOrderService(IBizOrderRepository bizOrderRepository) {
            this.bizOrderRepository = bizOrderRepository;
        }
        public BizOrderDTO GetBizOrder(int id) =>Map<BizOrderDTO>( bizOrderRepository.GetById(id));
    }
}
