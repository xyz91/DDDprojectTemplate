using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
namespace MediPlus.Domain.IRepositories
{
   public interface IUserRepository : IRepository <User,int>
    {
    }
}
