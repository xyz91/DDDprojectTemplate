using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
  public  interface IUnitOfWork
    {
        bool IsCommitted { get; set; }
        int Commit();
        void RollBack();
    }
}
