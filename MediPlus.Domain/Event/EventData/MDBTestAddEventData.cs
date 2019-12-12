using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.Event
{
   public class MDBTestAddEventData:EventData
    {
        public MDBTestAddEventData(User user) {
            this.User = user;
        }
        public User User { get; }
    }
}
