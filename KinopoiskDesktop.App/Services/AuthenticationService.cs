using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.IManagers;
using KinopoiskDesktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;
            if (CurrentUser != null)
                return false;

            return await _authenticationManager.Login(login, password);
        }

        public async Task<bool> Logout()
        {
            return await _authenticationManager.Logout();
        }

        public async Task<bool> Register(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;
            if (CurrentUser != null)
                return false;

            return await _authenticationManager.Register(login, password);
        }
    }
}
