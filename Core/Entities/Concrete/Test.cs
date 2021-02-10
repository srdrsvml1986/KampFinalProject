using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Test:IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}
