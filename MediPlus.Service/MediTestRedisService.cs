using MediPlus.Domain.IRepositories;
using MediPlus.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Service
{
  public  class MediTestRedisService: BaseService
    {
        private IMediTestRedisRepository repository;
        public MediTestRedisService(IMediTestRedisRepository repository) {
            this.repository = repository;
        }
        public bool StringSet(string key,string value) {
          return  repository.StringSet(key, value);
        }
    }
}
