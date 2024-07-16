using KinopoiskDesktop.Domain.Models;

namespace KinopoiskDesktop.Domain.IManagers
{
    public interface IAuthenticationManager
    {
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Login(string login, string password);

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Register(string login, string password);

        /// <summary>
        /// User logout
        /// </summary>
        /// <returns></returns>
        Task<bool> Logout();

        AppUser CurrentUser { get; }
        Guid? CurrentUserId { get; }
    }
}
