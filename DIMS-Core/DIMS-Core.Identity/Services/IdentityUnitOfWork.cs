using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.Identity.Services
{
    internal class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SignInManager { get; }

        public void Dispose()
        {
            UserManager?.Dispose();
        }
    }
}