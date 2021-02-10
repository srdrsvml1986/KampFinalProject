
namespace Core.Entities.Concrete
{
    public class UserClaim : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}
