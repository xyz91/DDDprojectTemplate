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
        private IMDBTestService testService;
        public BizOrderController(IBizOrderService bizOrderService,IHolidayService holidayService, IMDBTestService testService) {
            this.bizOrderService = bizOrderService;
            this.holidayService = holidayService;
            this.testService = testService;
        }
        //public BizOrderDTO Get()
        //{
        //    return bizOrderService.GetBizOrder(10967);
        //}

        public HolidayDTO Get()
        {

            MDBTestDTO dot = new MDBTestDTO {
                Name = "test1" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Id =14,
            };

            //testService.Insert(dot);
                                                                                          
          return  holidayService.GetDTOById("59e6b5307177b6dce454c387");
            //return "6666666666666666";
            // throw new Exception("错误测试");
           // return testService.GetMDBTest(5);

        }
    }
}