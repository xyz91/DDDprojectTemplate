using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeidPlus.Repository.RedisRepository
{
   public class MediTestRedisRepository: RedisBaseRepository, IMediTestRedisRepository
    {
        public MediTestRedisRepository(IMediPlusRedisContext mediPlusRedisContext):base(mediPlusRedisContext) {

        }
    }
}
