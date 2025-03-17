using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FUST.Ecommerce.Endpoints
{
	public static class AdminMaker
	{

		public static IEndpointRouteBuilder MapAdminMaker(
											   this IEndpointRouteBuilder app)
		{
			var group = app.MapGroup("api/admin/");
			group.MapPut("", RegisterAdmin);
			return app;
		}

		public static async Task<Ok> RegisterAdmin(string email, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
		{
			ApplicationUser? applicationUser = await _userManager.FindByEmailAsync(email);
			IdentityRole? role = await _roleManager.FindByNameAsync("Admin");
			if (role is null){
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}
			await _userManager.AddToRoleAsync(applicationUser, "Admin");

			return TypedResults.Ok();
		}
	}
}
