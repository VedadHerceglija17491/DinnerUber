using BubberDinner.Application.Common.Interfaces.Persistance;
using BubberDinner.Domain.Entities;

namespace BubberDinner.InfraStructure.Persistance
{
    public class UserRepository : IUserRepository
    {

        private static readonly  List<User> users = new List<User>();
        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(x => x.Email == email);
        }
    }
}
