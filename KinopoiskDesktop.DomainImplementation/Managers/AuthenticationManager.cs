using KinopoiskDesktop.DataAccess;
using KinopoiskDesktop.Domain.IManagers;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.DomainImplementation.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.DomainImplementation.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IApplicationDbContext _context;
        private AppUser? _currentUser;

        public AppUser CurrentUser
        {
            get { return _currentUser; }
            private set { _currentUser = value; }
        }

        public Guid? CurrentUserId => CurrentUser?.Id;

        public AuthenticationManager(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(string login, string password)
        {
            try
            {
                // Ошибка если пользователя с таким логином нет
                var dbUser = _context.AppUsers.FirstOrDefault(x => x.UserName == login);
                if (dbUser == null)
                {
                    return false;
                }

                // Ошибка если хэш введенного пароля и хэш в базе не совпадают
                if (!PasswordHelper.VerifyPassword(password, dbUser.PasswordHash, dbUser.PasswordSalt))
                {
                    return false;
                }

                dbUser.LoggedAt = DateTime.UtcNow;
                await _context.DbContext.SaveChangesAsync();
                _currentUser = dbUser;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Logout()
        {
            _currentUser = null;
            return true;
        }

        public async Task<bool> Register(string login, string password)
        {
            try
            {
                if (_context.AppUsers.Any(x => x.UserName == login))
                {
                    return false;
                }
                var hashedPassword = PasswordHelper.HashPasword(password, out var salt);
                _context.AppUsers.Add(new AppUser
                {
                    UserName = login,
                    PasswordHash = hashedPassword,
                    PasswordSalt = salt,
                    CreatedAt = DateTime.UtcNow,
                });
                await _context.DbContext.SaveChangesAsync();

                await Login(login, password);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
