using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
  public  interface IUnitOfWork
    {
        bool IsCommitted { get; set; }
        int Commit();
        Task<int> CommitAsync();
        void RollBack();
    }
}
