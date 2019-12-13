using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;

namespace MediPlus.Domain.Event
{
    public class MDBTestAddHandler : BaseEventHandler<MDBTestAddEventData>
    {
        private IUserRepository userRepository;
        public MDBTestAddHandler(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }
        public override void HandleEvent(MDBTestAddEventData eventData) {
           var test =  userRepository.GetById(2);
            Console.WriteLine(test.Id + test.Name);
            Console.WriteLine(eventData.User.Name+"&&&&&&&"+eventData.EventTime);
            test.ChangeName("oweitew");
           userRepository.Update(test);
        }
    }
    public class MDBTestAddHandler2 : BaseEventHandler<MDBTestAddEventData>
    {
        public override void HandleEvent(MDBTestAddEventData eventData)
        {
            Console.WriteLine(eventData.User.Name+"$$$$$$$$" + eventData.EventTime);
        }
    }
}
