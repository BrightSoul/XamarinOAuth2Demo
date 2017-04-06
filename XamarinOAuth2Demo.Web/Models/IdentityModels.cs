using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace XamarinOAuth2Demo.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserStore : IUserStore<ApplicationUser>, IUserLockoutStore<ApplicationUser, string>, IUserPasswordStore<ApplicationUser>, IUserTwoFactorStore<ApplicationUser, string>
    {
        public async Task CreateAsync(ApplicationUser user)
        {
           
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
        }

        public void Dispose()
        {
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            if ("Mario".Equals(userId, StringComparison.OrdinalIgnoreCase))
                return new ApplicationUser { Id = "Mario", UserName = "Mario" };
            return null;
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            if ("Mario".Equals(userName, StringComparison.OrdinalIgnoreCase))
                return new ApplicationUser { Id = "Mario", UserName = "Mario" };
            return null;
        }

        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return 0;
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return false;
        }

        public async Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            return new DateTimeOffset(DateTime.MinValue);
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return user.UserName == "Mario" ? "mario" : "";
        }

        public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return false;
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return user.UserName == "Mario";
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            return 0;
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
           
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
           
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
           
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
        }

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
           
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            
        }
    }

    public class PlainTextPasswordHasher : IPasswordHasher
    {
        //L'hash viene prodotto qui, durante la registrazione o il cambio password
        public string HashPassword(string password)
        {
            if (password.Equals(null))
                throw new ArgumentNullException("Devi fornire una password");

            return password;
        }

        //Il metodo di verfica viene invocato durante il login
        public PasswordVerificationResult
          VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var hashesMatch = hashedPassword.Equals(providedPassword,
              StringComparison.InvariantCultureIgnoreCase);

            return hashesMatch ?
              PasswordVerificationResult.Success :
              PasswordVerificationResult.Failed;
        }
    }


}