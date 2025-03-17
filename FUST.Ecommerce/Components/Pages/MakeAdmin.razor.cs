using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace FUST.Ecommerce.Components.Pages
{
	public partial class MakeAdmin(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
	{
		private EditContext? _editContext;
		public string Email = "";
		public string StatusContext;
		protected override async Task OnInitializedAsync()
		{

			_editContext = new EditContext(Email);
		}
		public async Task RegisterAdmin()
		{
			ApplicationUser? applicationUser = await UserManager.FindByEmailAsync(Email);
			if (applicationUser is not null)
			{
				IdentityRole? role = await RoleManager.FindByNameAsync("Admin");
				if (role is null)
				{
					await RoleManager.CreateAsync(new IdentityRole("Admin"));
				}
				await UserManager.AddToRoleAsync(applicationUser, "Admin");
			} else {
				StatusContext = "Something went wrong";
			}
		}
	}
}
