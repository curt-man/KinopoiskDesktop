using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.IManagers;
using KinopoiskDesktop.Domain.Models;

namespace KinopoiskDesktop.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationService(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public AppUser CurrentUser => _authenticationManager.CurrentUser;

        public Action<object, EventArgs> UserLoggedIn { get; set; }
        public Action<object, EventArgs> UserLoggedOut { get; set; }

        public async Task<bool> Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;
            if (CurrentUser != null)
                return false;

            var result =  await _authenticationManager.Login(login, password);
            if (result)
                UserLoggedIn?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public async Task<bool> Logout()
        {
            var result = await _authenticationManager.Logout();
            if (result)
                UserLoggedOut?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public async Task<bool> Register(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;
            if (CurrentUser != null)
                return false;

            var result = await _authenticationManager.Register(login, password);
            if (result)
                UserLoggedIn?.Invoke(this, EventArgs.Empty);
            return result;
        }
    }
}
