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
  //public  class MDBTestRepository : MongoBaseRepository<MediTest, int>, IMDBTestRepository
  //  {
  //      public MDBTestRepository(IMediPlusMongoContext unitOfWork):base(unitOfWork) {
           
  //      }

  //      public void SearchAll() {


  //          //db.MDBTest.aggregate([{'$unwind':'$Nodes'},{'$match':{'Nodes.Type':4}},{'$group': { "_id" :"$_id" ,"Nodes":{'$push':'$Nodes'} }}]);
  //          //db.MDBTest.aggregate([{ "$unwind" : "$Nodes" },{ "$match" : { "Nodes.Type" : 4 }   }, { "$group" : { "_id" :{"id":"$_id","Name":"$Name","SIDs":"$SIDs"},"Nodes":{"$push":"$Nodes"}  } },{"$project":{"_id":"$_id.id","Name":"$_id.Name","Sids":"$_id.SIDs","Nodes":"$Nodes"}}]);
  //          List< PipelineStageDefinition<MDBTest, MDBTest>> pipelines = new List<MongoDB.Driver.PipelineStageDefinition<MDBTest, MDBTest>>();

  //          var unwind = "{'$unwind':'$Nodes'}";
  //          PipelineStageDefinition<MDBTest, MDBTest> projectPipliness = new JsonPipelineStageDefinition<MDBTest, MDBTest>(unwind);

  //          pipelines.Add(projectPipliness);


  //          //aggregate([{ "$match" : { "_id" : 16 } }])
  //          //{aggregate([{ "$project" : { "__fld0" : { "$filter" : { "input" : "$Nodes", "as" : "b", "cond" : { "$eq" : ["$$b.Type", 4] } } }, "_id" : 0 } }])}
  //          var match = Entities.Where(a=>a.Nodes.Any(b=>b.Type==4) && a.Id == 16);
  //          var matchstr = "{'$match':{'Nodes.Type':4}}";
  //          PipelineStageDefinition<MDBTest, MDBTest> queryPipline = new JsonPipelineStageDefinition<MDBTest, MDBTest>(match.ToString().Replace("aggregate([", "").Trim(')',']'));
  //          PipelineStageDefinition<MDBTest, MDBTest> queryPiplinestr = new JsonPipelineStageDefinition<MDBTest, MDBTest>(matchstr);

  //          pipelines.Add(queryPiplinestr);

  //          var project = Entities.Select(a=>new {a.Id,a.Name,Nodes = new[] { new ChildNode { } } });
  //          // PipelineStageDefinition<MDBTest, MDBTest> projectPipline = new JsonPipelineStageDefinition<MDBTest, MDBTest>(project.ToString().Replace("aggregate([", "").Trim(')', ']'));

  //          // pipelines.Add(projectPipline);
  //          //db.MDBTest.aggregate([{'$unwind':'$Nodes'},{'$match':{'Nodes.Type':4}},{'$group': { "_id" : "$_id" ,"Nodes":{'$push':'$Nodes'} }}]);
  //          var groupby = Entities.GroupBy(a=>a.Id);    //只能一个字段id，多个字段结果 的_id 会是复合头，无法反序列化到对象
  //          var groupbystr = groupby.ToString().Replace("aggregate([", "").Trim(')', ']');

  //          groupbystr = groupbystr.Substring(0,groupbystr.Length-3) + ",'Nodes':{'$push':'$Nodes'}}}";
  //          PipelineStageDefinition<MDBTest, MDBTest> grouppipline = new JsonPipelineStageDefinition<MDBTest, MDBTest>(groupbystr);
  //          pipelines.Add(grouppipline);
                          
  //          //ProjectionDefinition<MDBTest, MDBTest> definition = new ProjectionDefinition<MDBTest, MDBTest>();
  //        //  ProjectionDefinitionBuilder<MDBTest> builder = new ProjectionDefinitionBuilder<MDBTest>();
  //        // var par =  builder.Expression<MDBTest>(a => new MDBTest(a.Id, a.Name) { SIDs = a.SIDs});
  //        //var oooo =     Collection.Aggregate().Match(a=>a.Nodes.Any(b=>b.Type==4)).Unwind<MDBTest, MDBTest>(a => a.Nodes).Group(par);
  //       //var ooowfe =   oooo.ToList();    
  //          PipelineDefinition<MDBTest, MDBTest> pipe = new PipelineStagePipelineDefinition<MDBTest, MDBTest>(pipelines);
  //         var result =    Collection.Aggregate<MDBTest>(pipe).ToList();
       
  //      }
  //  }
}
