using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MeidPlus.Repository
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext Context { get; }
    }
}
