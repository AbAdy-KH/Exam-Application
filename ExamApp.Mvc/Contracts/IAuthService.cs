using ExamApp.Mvc.Models;

namespace ExamApp.Mvc.Contracts
{
    public interface IAuthService
    {
        Task<bool> Authunticate(AuthunticationVM obj);
        Task<bool> Register(RegisterVM obj);
        Task Logout();
    }
}
