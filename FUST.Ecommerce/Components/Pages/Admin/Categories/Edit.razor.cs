using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Services;
using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Components.Pages.Admin.Categories
{
	public partial class Edit(ICategoryDataAccess data, NavigationManager nav, UserManager<ApplicationUser> UserManager)
	{
		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }

		private EditContext? _editContext;
		private Category Input { get; set; } = new();

		public bool CategoryExist { get; set; } = false;

		[Parameter]
		public int Id { get; set; }
		public string StatusConstraints { get; private set; }

		protected async override Task OnInitializedAsync()
		{
			var state = await AuthState;
			var user = state.User;

			_editContext = new EditContext(Input);
			Category? foundCategory = await data.GetCategoryAsync(Id);
			if (foundCategory is not null)
			{
				Input.Name = foundCategory.Name;
				Input.Id = foundCategory.Id;
				CategoryExist = true;
			}
		}

		private async Task Update()
		{
			Input.Id = Id;
			if (await data.UpdateCategoryAsync(Input))
			{
				nav.NavigateTo("/admin/categories/");
			}
			else
			{
				StatusConstraints = "Something went wrong with insert method";
			}
		}
	}
}
