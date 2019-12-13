using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Context;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.Service
{
  public  class UserRoleDomains : IUserRoleDomains
    {
        private IUserRepository userRepository;
        private IMDBTestRepository testRepository;
        private IMediPlusContext context;
        public UserRoleDomains(IUserRepository userRepository,IMDBTestRepository testRepository, IMediPlusContext context) {
            this.userRepository = userRepository;
            this.testRepository = testRepository;
            this.context = context;
        }
        public void Test() {
            
           var user = userRepository.GetById(1);
            var test = userRepository.GetById(2);

            user.ChangeName("test1");
            test.ChangeName("test2");
            context.RegisUpdate<User,int>(user);
            context.RegisUpdate<User,int>(test);
            context.Commit();
        }
    }
}
