using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Models;
using FUST.Ecommerce.Services;

namespace FUST.Ecommerce.Components.Pages.Admin.Products
{
	public partial class Create(IProductDataAccess data, ICategoryDataAccess dataCategory, NavigationManager nav, UserManager<ApplicationUser> UserManager)
	{
		private EditContext? _editContext;
		private Product Input { get; set; } = new();
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
			if (await dataCategory.GetCategoryAsync(Input.CategoryId) is not null)
			{
				if(await data.AddProductAsync(Input))
				{
					nav.NavigateTo("/admin/products/");
				}
				StatusConstraints = "Something went wrong with insert method";
			} else
			{
				StatusConstraints = "Category Id is not valid, input an existing category id";
			}
		}
	}

}
