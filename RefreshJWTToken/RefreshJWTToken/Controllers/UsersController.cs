using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefreshJWTToken.Models;
using RefreshJWTToken.Models.UserRoleModel;
using RefreshJWTToken.Repository.JWT;
using RefreshJWTToken.Repository.UserService;
using RefreshJWTToken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshJWTToken.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IJWTManagerRepository _jWTManager;
		private readonly IUserServiceRepository _userServiceRepository;
		private readonly UserManager<IdentityUser> _userManager;

		public UsersController(IJWTManagerRepository jWTManager, IUserServiceRepository userServiceRepository, UserManager<IdentityUser> userManager)
		{
			_jWTManager = jWTManager;
			_userServiceRepository = userServiceRepository;
			_userManager = userManager;
		}

		[Authorize(Roles = "admin")]
		[HttpGet]
		[Route("role")]
		public IActionResult GetUser()
		{
			return Ok();
		}

		[HttpPut]
		[Route("editname")]
		public async Task<IActionResult> EditName(ChangeUserNameViewModel model)
		{
            if (model == null || String.IsNullOrEmpty(model.OldUserName))
				return BadRequest();

			else if(String.IsNullOrEmpty(model.NewUserName) )
				return BadRequest(new { error = "Input is empty"});

			else if(model.NewUserName.Length < 4)
				return BadRequest(new { error = "Length less than 4" });

			else if (model.NewUserName == model.OldUserName)
				return BadRequest(new { error = "The old username cannot be the same as the new one" });

			try
            {
				if(await _userServiceRepository.EditNameAsync(model))
					return Ok(new { newUserName = model.NewUserName });
			}
            catch (Exception ex)
            {
				return BadRequest(new { error = ex.Message });
			}
			return BadRequest();
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(UserModel user)
		{
			if (user == null || String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password)) 
				return NotFound();
			var validUser = await _userServiceRepository.IsValidUserAsync(user);

			if (validUser != null)
			{
				var token = await AuthenticateAsync(validUser);
				if (token != null)
				{
					return Ok(new { acces = token.Access_Token, refresh = token.Refresh_Token, name = validUser.UserName, email = validUser.Email });
				}
			}
			return NotFound( new { error = "Not correct login or password" });
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register(UserModel user)
		{
			if (user == null || String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password) || String.IsNullOrEmpty(user.Name))
				return BadRequest();


			var result = await _userManager.CreateAsync(new IdentityUser { UserName = user.Name, Email = user.Email }, user.Password);
			if (result.Succeeded)
			{

				var userDb = await _userManager.FindByNameAsync(user.Name);
				result = await _userManager.AddToRoleAsync(userDb, "user");
				if (result.Succeeded)
				{
					var validUser = await _userServiceRepository.IsValidUserAsync(user);

					if (validUser != null)
					{
						var token = await AuthenticateAsync(validUser);
						return Ok(new { acces = token.Access_Token, refresh = token.Refresh_Token });
					}
					
				}
			}
			var erors = result.Errors.Select(x => x.Description).ToList();
			return NotFound(erors);
		}

		
		private async Task<Tokens> AuthenticateAsync(IdentityUser validUser)
		{
			
			
			var roles = await _userServiceRepository.GetRoles(validUser.Email);
			var token = _jWTManager.GenerateToken(new UserRefreshWithrRolesModel { Role = roles[0], Email = validUser.Email });

			if (token == null)
			{
				return null;
			}

			// saving refresh token to the db
			UserRefreshTokens obj = new UserRefreshTokens
			{
				RefreshToken = token.Refresh_Token,
				UserName = validUser.Email
			};
			_userServiceRepository.AddUserRefreshTokens(obj);
			_userServiceRepository.SaveCommit();
			return token;
		}

		[AllowAnonymous]
		[HttpDelete]
		[Route("logout")]
		public IActionResult LogOut(Tokens token)
        {
			var principal = _jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
			if (principal == null)
				return Unauthorized("Invalid JWT!");

			_userServiceRepository.DeleteUserRefreshTokens(principal.Identity?.Name, token.Refresh_Token);
			
			
			return Ok();
		}

		

		[AllowAnonymous]
		[HttpPost]
		[Route("refresh")]
		public async Task <IActionResult> Refresh(Tokens token)
		{
			var principal = _jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
			if(principal == null) 
				return BadRequest();

			var userEmail = principal.Identity?.Name;

			//retrieve the saved refresh token from database
			var savedRefreshToken = _userServiceRepository.GetSavedRefreshTokens(principal.Identity?.Name, token.Refresh_Token);

			if (savedRefreshToken is null || savedRefreshToken.RefreshToken != token.Refresh_Token )
			{
				return Unauthorized("Invalid attempt!");
			}
			
			var user = await _userServiceRepository.GetUser(userEmail);
			user.RefreshToken = savedRefreshToken;

			var newJwtToken = _jWTManager.GenerateRefreshToken(user);

			if (newJwtToken == null)
			{
				return Unauthorized("Invalid attempt!");
			}


			if (token.Refresh_Token != newJwtToken.Refresh_Token)
			{
				_userServiceRepository.DeleteUserRefreshTokens(userEmail, token.Refresh_Token); //disactiv old token
				_userServiceRepository.AddUserRefreshTokens(new UserRefreshTokens // saving refresh token to the db
				{
					RefreshToken = newJwtToken.Refresh_Token,
					UserName = userEmail
				});
				_userServiceRepository.SaveCommit();
			}

			return Ok( new { acces = newJwtToken.Access_Token, refresh = newJwtToken.Refresh_Token });
		}

		
	}
}
