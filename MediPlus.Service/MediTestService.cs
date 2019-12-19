using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Interface;
using System.Threading.Tasks;

namespace MediPlus.Service
{
    internal class MediTestService : BaseUnitService<MediTest, string, MediTestDTO>, IMediTestService
    {
        private new readonly IMediTestEFRepository repository;
        public MediTestService(IMediTestEFRepository repository) : base(repository) => this.repository = repository;
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
    }
}
