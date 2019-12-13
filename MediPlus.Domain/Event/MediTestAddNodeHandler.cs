using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.IRepositories;

namespace MediPlus.Domain.Event
{
    public class MediTestAddNodeHandler : BaseEventHandler<MediTestAddNodeEventData>
    {
        public override void HandleEvent(MediTestAddNodeEventData eventData) => Console.WriteLine("add event %%%%%&&&&&$$$$");
    }
}
