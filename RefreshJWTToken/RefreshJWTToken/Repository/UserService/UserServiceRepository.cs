using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RefreshJWTToken.Data;
using RefreshJWTToken.Models;
using RefreshJWTToken.Models.UserRoleModel;
using RefreshJWTToken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshJWTToken.Repository.UserService
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _db;

        public UserServiceRepository(UserManager<IdentityUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
            
        }
        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            _db.UserRefreshToken.Add(user);
            return user;
        }

        public async Task<bool> EditNameAsync(ChangeUserNameViewModel model)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserName == model.OldUserName);
            if (user != null)
            {
                var checkName = await _db.Users.FirstOrDefaultAsync(x => x.UserName == model.NewUserName);
                if (checkName == null)
                {
                    user.UserName = model.NewUserName;
                    user.NormalizedUserName = _userManager.NormalizeEmail(model.NewUserName);
                    _db.Users.Update(user);
                    SaveCommit();
                    return true;

                }

                throw new Exception("A user with this nickname already exists");


            }
            throw new Exception("User is not found");
            
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            
            if (item != null)
            {
                item.IsActive = false;
                _db.UserRefreshToken.Update(item);
                SaveCommit();
            }
        }

        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken)
        {
            return _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
        }

        public async Task<UserRefreshWithrRolesModel> GetUser(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var roles = await GetRoles(userEmail);
            return new UserRefreshWithrRolesModel { Email = user.Email, Name = user.UserName, Role = roles[0] };
        }
        public async Task<List<string>> GetRoles(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
        public async Task<IdentityUser> IsValidUserAsync(UserModel user)
        {
            var dbUSer = _userManager.Users.Where(o => o.Email == user.Email || o.UserName == user.Name || o.UserName == user.Email).FirstOrDefault();
            var result = await _userManager.CheckPasswordAsync(dbUSer, user.Password);
            if (result == false)
                return null;

            return dbUSer;
        }
        public int SaveCommit()
        {
            return _db.SaveChanges();
        }
    }
}
