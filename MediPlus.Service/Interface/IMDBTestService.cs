using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service.Interface
{
   public interface IMDBTestService  : IBaseUnitService<MDBTest, int, MDBTestDTO>
    {
        IEnumerable<MDBTestDTO> Searcha(MDBTestDTOPage page);
    }
}
