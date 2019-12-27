using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Interface;
using System;
using System.Threading.Tasks;

namespace MediPlus.Service
{
    internal class MediTestService : BaseUnitService<MediTest, string, MediTestDTO>, IMediTestService
    {
        private new readonly IMediTestEFRepository repository;
        private IMediTestRedisRepository redisRepository;
        public MediTestService(IMediTestEFRepository repository, IMediTestRedisRepository redisRepository) : base(repository) {
            this.repository = repository;
            this.redisRepository = redisRepository;
        }
        public int AddNode(string id, params MediTestNodeDTO[] dto)
        {
            MediTest medi = GetById(id);
            medi.AddNode(Map<MediTestNodeDTO[], MediTestNode[]>(dto));
            return Update(medi);
        }

        public async Task<int> AddNodeAsync(string id, params MediTestNodeDTO[] dto)
        {
            MediTest medi = await GetByIdAsnyc(id);
            medi.AddNode(Map<MediTestNodeDTO[], MediTestNode[]>(dto));
            return await UpdateAsync(medi);
        }

        public bool StringSet(string key,string value,int time) {
           return redisRepository.StringSet(key, value,time);
        }
        public string StringGet(string key) {
            return redisRepository.StringGet(key);
        }
    }
}
