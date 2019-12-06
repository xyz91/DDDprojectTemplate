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
    public class BizOrderService : BaseService<BizOrder, int,BizOrderDTO>, IBizOrderService
    {
        public BizOrderService(IBizOrderRepository bizOrderRepository):base(bizOrderRepository) {
        }
    }
}
