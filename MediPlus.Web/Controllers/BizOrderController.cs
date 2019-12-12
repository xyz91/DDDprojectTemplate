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

        public  int Get()
        {

                MDBTestDTOPage page = new MDBTestDTOPage {Type = 4,PageSize = 2};
                testService.Searcha(page).ToArray();

            return 2;

            //MDBTestDTO dot = new MDBTestDTO {
            //    Name = "test2" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //    Id = 19,
            //    SIDs =new[]{ 3,25,37},
            //    Nodes = new[] { 
            //    new ChildNodeDTO{ Name="node0_0",Type = 2},
            //      new ChildNodeDTO{ Name="node0_1",Type = 3},
            //      new ChildNodeDTO{ Name="node0_2",Type = 4}
            //    },
            //};

            //MDBTestDTO dot1 = new MDBTestDTO
            //{
            //    Name = "test2" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //    Id = 17,
            //    SIDs = new[] { 14, 15, 42 },
            //    Nodes = new[] {
            //    new ChildNodeDTO{ Name="node1_0",Type = 3},
            //      new ChildNodeDTO{ Name="node1_1",Type = 4},
            //      new ChildNodeDTO{ Name="node1_2",Type = 5}
            //    },
            //};
            //MDBTestDTO dot2 = new MDBTestDTO
            //{
            //    Name = "test2" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //    Id = 18,
            //    SIDs = new[] { 26, 34, 42 },
            //    Nodes = new[] {
            //    new ChildNodeDTO{ Name="node2_0",Type = 5},
            //      new ChildNodeDTO{ Name="node2_1",Type = 6},
            //      new ChildNodeDTO{ Name="node2_2",Type = 7}
            //    },
            //};
            //   testService.Insert(dot);
            //testService.Insert(dot1);
            //testService.Insert(dot2);
            //return 3;
            // return  holidayService.GetDTOById("59e6b5307177b6dce454c387");
            //return "6666666666666666";
            // throw new Exception("错误测试");
            // return testService.GetMDBTest(5);

        }
    }
}