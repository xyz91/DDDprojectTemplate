﻿using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories.BaseRepository;

namespace MediPlus.Domain.IRepositories.Context
{
   public interface IEFBaseContext : IUnitOfWork, IUnionOfWork
    {
    }
}
