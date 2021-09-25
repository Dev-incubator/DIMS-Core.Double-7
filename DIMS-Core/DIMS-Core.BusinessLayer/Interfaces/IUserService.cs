using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IUserService : IIdentityService
    {
        Task<SignInResult> SignInAsync(SignInModel model);

        Task SignOutAsync();

        Task<IdentityResult> SignUpAsync(SignUpModel model);
    }
}