using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;

namespace MediPlus.Domain.Service
{
  public  class UserRoleService: IUserRoleService
    {
        private IUserRepository userRepository;
        private IMDBTestRepository testRepository;
        public UserRoleService(IUserRepository userRepository,IMDBTestRepository testRepository) {
            this.userRepository = userRepository;
            this.testRepository = testRepository;
        }
        public void Test(int i) {
           var user = userRepository.GetById(i);
            var test = testRepository.GetById(i);
        }
    }
}
