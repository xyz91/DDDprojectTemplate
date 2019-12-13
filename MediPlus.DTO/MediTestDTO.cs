using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
    public class MediTestDTO:EntityDTO<string>
    {
        public string Name { get; set; }
        public List<MediTestNodeDTO> MediTestNodes { get; set; }
    }
}
