using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediPlus.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MediPlus.DTO;

namespace MediPlus.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BizOrderController : Controller
    {
        private IBizOrderService bizOrderService;
        private IHolidayService holidayService;
        public BizOrderController(IBizOrderService bizOrderService,IHolidayService holidayService) {
            this.bizOrderService = bizOrderService;
            this.holidayService = holidayService;
        }
        //public BizOrderDTO Get()
        //{
        //    return bizOrderService.GetBizOrder(10967);
        //}

        public string Get()
        {
            
            //return "6666666666666666";
            throw new Exception("错误测试");
            //return holidayService.GetBHoliday("5ddcc6b9b1900f855082a304");

        }
    }
}