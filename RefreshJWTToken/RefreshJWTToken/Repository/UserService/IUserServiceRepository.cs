using Microsoft.AspNetCore.Identity;
using RefreshJWTToken.Models;
using RefreshJWTToken.Models.UserRoleModel;
using RefreshJWTToken.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefreshJWTToken.Repository.UserService
{
    public interface IUserServiceRepository
    {
		Task<IdentityUser> IsValidUserAsync(UserModel users);
		UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);
		Task<bool> EditNameAsync(ChangeUserNameViewModel model);
		UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken);
		void DeleteUserRefreshTokens(string username, string refreshToken);
		Task<UserRefreshWithrRolesModel> GetUser(string userEmail);
		Task<List<string>> GetRoles(string userEmail);
		int SaveCommit();
	}
}
