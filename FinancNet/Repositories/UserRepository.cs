using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using System.Linq;

namespace FinancNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context.Context _ctx;

        public UserRepository(Context.Context ctx)
        {
            _ctx = ctx;
        }

        public User Create(User user)
        {
            _ctx.User.Add(user);
            _ctx.SaveChanges();
            return user;
        }

        public User FindByLogin(string login) =>
            _ctx.User.SingleOrDefault(u => u.Login.Equals(login));
    }
}
