
using System.Collections;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class UserGroup : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
