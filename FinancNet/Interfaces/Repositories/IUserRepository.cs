using FinancNet.Entities;

namespace FinancNet.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User FindByLogin(string login);
    }
}
