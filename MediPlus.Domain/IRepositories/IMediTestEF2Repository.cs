using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.IRepositories
{
    public interface IMediTestEF2Repository  : IRepository<MediTest, string>, IEFRepository<MediTest, string>
    {
    }
}
