using KinopoiskDesktop.Domain.Models;

namespace KinopoiskDesktop.App.Services.IService
{
    /// <summary>
    /// Service for user authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Login(string login, string password);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Register(string login, string password);

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        Task<bool> Logout();

        /// <summary>
        /// Current logged in user
        /// </summary>
        AppUser CurrentUser { get; }

        /// <summary>
        /// Event that is triggered when user logs in
        /// </summary>
        Action<object, EventArgs> UserLoggedIn { get; set; }

        /// <summary>
        /// Event that is triggered when user logs out
        /// </summary>
        Action<object, EventArgs> UserLoggedOut { get; set; }
    }
}
