using System;
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
  public  class MDBTestRepository : MongoBaseRepository<MDBTest,int>, IMDBTestRepository
    {
        public MDBTestRepository(MediplusContext unitOfWork):base(unitOfWork) {
           
        }

        public void SearchAll() {
            List< PipelineStageDefinition<MDBTest, MDBTest>> pipelines = new List<MongoDB.Driver.PipelineStageDefinition<MDBTest, MDBTest>>();
            

            

            //aggregate([{ "$match" : { "_id" : 16 } }])
            //{aggregate([{ "$project" : { "__fld0" : { "$filter" : { "input" : "$Nodes", "as" : "b", "cond" : { "$eq" : ["$$b.Type", 4] } } }, "_id" : 0 } }])}
            var match = Entities.Where(a=>a.Nodes.Any(b=>b.Type==4));
            var matchstr = "{'$match':{'Nodes.Type':4}}";
            PipelineStageDefinition<MDBTest, MDBTest> queryPipline = new JsonPipelineStageDefinition<MDBTest, MDBTest>(match.ToString().Replace("aggregate([", "").Trim(')',']'));
            PipelineStageDefinition<MDBTest, MDBTest> queryPiplinestr = new JsonPipelineStageDefinition<MDBTest, MDBTest>(matchstr);

            pipelines.Add(queryPiplinestr);

            var project = Entities.Select(a=>new {a.Id,a.Name,Nodes = new[] { new ChildNode { } } });
            PipelineStageDefinition<MDBTest, MDBTest> projectPipline = new JsonPipelineStageDefinition<MDBTest, MDBTest>(project.ToString().Replace("aggregate([", "").Trim(')', ']'));

            // pipelines.Add(projectPipline);

            var unwind = "{'$unwind':'$Nodes'}";
            PipelineStageDefinition<MDBTest, MDBTest> projectPipliness = new JsonPipelineStageDefinition<MDBTest, MDBTest>(unwind);

            pipelines.Add(projectPipliness);

            PipelineDefinition<MDBTest, MDBTest> pipe = new PipelineStagePipelineDefinition<MDBTest, MDBTest>(pipelines);
           var result =    Collection.Aggregate<MDBTest>(pipe).ToList();
       
        }
    }
}
