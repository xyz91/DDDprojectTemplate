using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model.BaseModel
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="K"></typeparam>
    interface IAggregateRoot<K>:IEntity
    {
    }
}
