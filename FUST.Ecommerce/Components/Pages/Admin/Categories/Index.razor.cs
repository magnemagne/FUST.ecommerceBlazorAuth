using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Services;
using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Components.Pages.Admin.Categories
{
	public partial class Index(ICategoryDataAccess data,UserManager<ApplicationUser> UserManager)
	{

		private IEnumerable<Category>? _categories;

		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }


		protected override async Task OnInitializedAsync()
		{
			//var state = await AuthState;
			//var user = state.User;

			_categories = await data.GetCategoriesAsync();
		}

		protected override void OnParametersSet()
		{
			base.OnParametersSet();
		}

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
		}
	}
}
