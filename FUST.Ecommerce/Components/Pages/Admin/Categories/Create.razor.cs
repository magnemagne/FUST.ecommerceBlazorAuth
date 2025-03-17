using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Models;
using FUST.Ecommerce.Services;

namespace FUST.Ecommerce.Components.Pages.Admin.Categories
{
	public partial class Create(ICategoryDataAccess data, NavigationManager nav, UserManager<ApplicationUser> UserManager)
	{
		private EditContext? _editContext;
		private Category Input { get; set; } = new();
		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }
		[Parameter]
		public int Id { get; set; }
		public string StatusConstraints { get; private set; }

		protected override async Task OnInitializedAsync()
		{
			var state = await AuthState;
			var user = state.User;

			_editContext = new EditContext(Input);
		}

		private async void Save()
		{
			if (await data.AddCategoryAsync(Input)){
				nav.NavigateTo("/admin/categories/");
			} else { 
				StatusConstraints = "Something went wrong with insert method"; 
			}
		}
	}

}
