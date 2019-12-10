using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;
using System.Linq;
using MediPlus.Utility;
namespace MediPlus.Service
{
    public class MDBTestService : BaseService<MDBTest,int,MDBTestDTO>, IMDBTestService
    {
        private new IMDBTestRepository repository;
        public MDBTestService(IMDBTestRepository repository):base(repository){

            this.repository = repository;
        }


       public IEnumerable<MDBTestDTO> Searcha(MDBTestDTOPage page) {

            repository.SearchAll();

            Expression<Func<MDBTest, bool>> expression = a => true;
            if (page.Id != null)
            {
                expression = expression.And(a=>a.Id == page.Id);
            }
            if (page.SIDs != null)
            {
                expression = expression.And(a=>a.SIDs.Contains(page.SIDs.Value));
            }
            if (page.Type != null)
            {
                expression = expression.And(a=>a.Nodes.Any(b=>b.Type==page.Type.Value));
            }
          var ooo =  repository.Entities.Where(a => a.Nodes.Any(b => b.Type == page.Type.Value)).SelectMany(a => a.Nodes).ToList();

          var oooooo =   repository.Entities.SelectMany(a => a.Nodes).Where(a=>a.Type==page.Type.Value).ToArray();
            //var o = from a in repository.Entities
            //        select  new
            //        {    a.Id, a.Name,
            //           node= a.Nodes.Where(c => c.Type == page.Type.Value)
            //        };
            //var ooo3ooo = o.ToArray();
            
            var mdbtest = Search(expression,page.PageIndex,page.PageSize).ToArray();
        // var oo34o =   repository.Entities.Aggregate(16, (a, b) => a + b.Id, a => a);
            

            //typeof(Expression<Func<MDBTest, bool>>).MakeGenericType()
            return Map<MDBTest[], MDBTestDTO[]>(mdbtest.ToArray());
            //return Search(expression, pageIndex, pageSize);
        }
    }
}
