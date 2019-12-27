using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service.Interface
{
   public interface IMediTestService : IBaseUnitService<MediTest, string, MediTestDTO>
    {
        int AddNode(string id,params MediTestNodeDTO[] dto);
        Task<int> AddNodeAsync(string id, params MediTestNodeDTO[] dto);
        bool StringSet(string key, string value, int time);
        string StringGet(string key);
    }
}
