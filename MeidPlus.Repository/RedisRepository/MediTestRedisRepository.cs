using MediPlus.Domain.IRepositories;
using MeidPlus.Repository.RedisRepository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeidPlus.Repository.RedisRepository
{
   public class MediTestRedisRepository: RedisBaseRepository, IMediTestRedisRepository
    {
        public MediTestRedisRepository(MediPlusRedisContext mediPlusRedisContext):base(mediPlusRedisContext) {

        }
    }
}
