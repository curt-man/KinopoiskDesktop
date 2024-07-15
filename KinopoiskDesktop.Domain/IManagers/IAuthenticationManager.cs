using KinopoiskDesktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.IManagers
{
    public interface IAuthenticationManager
    {
        Task<bool> Login(string login, string password);
        Task<bool> Register(string login, string password);
        Task<bool> Logout();

        AppUser CurrentUser { get; }
    }
}
