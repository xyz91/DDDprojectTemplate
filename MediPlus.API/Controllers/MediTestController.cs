using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediPlus.DTO;
using MediPlus.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.API.Controllers
{
    public class MediTestController : Controller
    {
        private IMediTestService mediTestService;
        private IMediTest2Service mediTest2Service;
        private IMediTestMongoService mediTestMongoService;
        public MediTestController(IMediTestService mediTestService,IMediTest2Service mediTest2Service,IMediTestMongoService mediTestMongoService) {
            this.mediTestService = mediTestService;
            this.mediTest2Service = mediTest2Service;
            this.mediTestMongoService = mediTestMongoService;
        }
        public string Index() {
            return "ok";
        }
        //[HttpGet]
        //public PagingDTO<MediTestDTO> Searchef() {
        //   return  mediTestService.Search(1, 10);
        //}
        [HttpGet]
        public Task<PagingDTO<MediTestDTO>> SearchefAsync() {
            return mediTestService.SearchAsync(1, 10);
        }
        [HttpPost]
        public int AddNode([FromBody]MediTestDTO medi) {
            return mediTestService.AddNode(medi.Id, medi.MediTestNodes?.ToArray());
        }
        [HttpPost]
        public Task<int> AddNodeAsync([FromBody]MediTestDTO medi) {
            return mediTestService.AddNodeAsync(medi.Id, medi.MediTestNodes?.ToArray());
        }
        [HttpGet]
        public PagingDTO<MediTestDTO> Searchef2()
        {
            return mediTest2Service.Search(1, 10);
        }
        [HttpGet]
        public PagingDTO<MediTestDTO> Searchmongo()
        {
            return mediTestMongoService.Search(1, 10);
        }
        [HttpGet]
        public MediTestDTO Getef(string id) {
            return mediTestService.GetDTOById(id);
        }
        [HttpGet]
        public MediTestDTO Getef2(string id)
        {
            return mediTest2Service.GetDTOById(id);
        }
        [HttpGet]
        public MediTestDTO Getmongo(string id)
        {
            return mediTestMongoService.GetDTOById(id);
        }
        [HttpPost]
        public int Addef([FromBody]MediTestDTO mediTest)
        {
            return mediTestService.Insert(mediTest);
        }
        [HttpPost]
        public int Addef2([FromBody]MediTestDTO mediTest)
        {
            return mediTest2Service.Insert(mediTest);
        }
        [HttpPost]
        public int Addmongo([FromBody]MediTestDTO mediTest)
        {
            return mediTestMongoService.Insert(mediTest);
        }
        [HttpPost]
        public int Updateef([FromBody]MediTestDTO mediTest)
        {
            return mediTestService.Update(mediTest);
        }
        [HttpPost]
        public int Updateef2([FromBody]MediTestDTO mediTest)
        {
            return mediTest2Service.Update(mediTest);
        }
        [HttpPost]
        public int Updatemongo([FromBody]MediTestDTO mediTest)
        {
            return mediTestMongoService.Update(mediTest);
        }
        [HttpPost]
        public int Deleteef(string id) {
            return mediTestService.Delete(id);
        }
        [HttpPost]
        public int Deleteef2(string id)
        {
            return mediTest2Service.Delete(id);
        }
        [HttpPost]
        public int Deletemongo(string id)
        {
            return mediTestMongoService.Delete(id);
        }

        public bool StringSet(string key,string value) {
            return mediTestService.StringSet(key, value, 60*60);
        }
        public string StringGet(string key) {
            return mediTestService.StringGet(key);
        }
    }
}