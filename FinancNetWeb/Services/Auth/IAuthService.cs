using FinancNetWeb.Models;

namespace FinancNetWeb.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);

        Task Logout();
    }
}
