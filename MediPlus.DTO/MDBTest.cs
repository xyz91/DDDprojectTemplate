using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public class MDBTestDTO     : EntityDTO<int>
    {
        public string Name { get; set; }
        public IEnumerable<int> SIDs { get; set; }
        public IEnumerable<ChildNodeDTO> Nodes { get; set; }
    }
    public class ChildNodeDTO
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
    public class MDBTestDTOPage : PageBase<MDBTestDTO, int>
    { 
        public int? Id { get; set; }
        public int? SIDs { get; set; }
        public int? Type { get; set; }
    }
}
