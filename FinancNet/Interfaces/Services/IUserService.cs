using FinancNet.Dtos;
using FinancNet.Entities;

namespace FinancNet.Interfaces.Services
{
    public interface IUserService
    {
        object Create(User user);
        object FindByLogin(LoginDTO login);
    }
}
