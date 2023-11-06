using System.Formats.Asn1;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles {get;}
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        
        Task<IdentityUser> GetOneUser(string userName);
        Task Update(UserDtoForUpdate userDto);
        Task <UserDtoForUpdate> GetOneUserForUpdate (string userName);
        Task <IdentityResult> ResetPassword(ResetPasswordDto model);
        Task <IdentityResult> DeleteOneUser(string userName);

        
    }

}