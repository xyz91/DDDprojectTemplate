using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
  public  class BizOrder : AggregateRoot<int>
    {
        public BizOrder(int id) : base(id) { }
        public BizOrder(int id,decimal price):this(id) {
            this.Price = price;
        }
        public decimal Price { get; set; }

    }
}
