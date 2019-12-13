using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Context;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.Service
{
  public  class MediTestDomains : IMediTestDomains
    {
        private IMediTestEFRepository userRepository;
        private IMediTestEF2Repository testRepository;
        private IMediPlusContext context;
        public MediTestDomains(IMediTestEFRepository userRepository, IMediTestEF2Repository testRepository, IMediPlusContext context) {
            this.userRepository = userRepository;
            this.testRepository = testRepository;
            this.context = context;
        }
        public void Test() {
         
        }
    }
}
