using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.Service
{
  public  class MediTestDomains : IMediTestDomains
    {
        private IMediTestEFRepository userRepository;
        private IMediTestEF2Repository testRepository;
        public MediTestDomains(IMediTestEFRepository userRepository, IMediTestEF2Repository testRepository) {
            this.userRepository = userRepository;
            this.testRepository = testRepository;
          
        }
        public void Test() {
         
        }
    }
}
