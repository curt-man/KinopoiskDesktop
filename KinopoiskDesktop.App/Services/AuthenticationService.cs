using KinopoiskDesktop.App.Services.IService;
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
        private AppUser _currentUser;

        public AppUser CurrentUser
        {
            get { return _currentUser; }
            private set { _currentUser = value; }
        }

        public Task<bool> Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
