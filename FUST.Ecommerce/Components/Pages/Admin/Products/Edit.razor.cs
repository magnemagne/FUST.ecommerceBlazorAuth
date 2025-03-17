using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Services;
using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Components.Pages.Admin.Products
{
	public partial class Edit(IProductDataAccess data, ICategoryDataAccess dataCategory, NavigationManager nav, UserManager<ApplicationUser> UserManager)
	{
		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }

		private EditContext? _editContext;
		private Product Input { get; set; } = new();

		public bool ProductExists { get; set; } = false;

		[Parameter]
		public int Id { get; set; }

		public string StatusConstraints;


		protected async override Task OnInitializedAsync()
		{
			var state = await AuthState;
			var user = state.User;

			_editContext = new EditContext(Input);
			Product? foundProduct = await data.GetProductAsync(Id);
			if (foundProduct is not null)
			{
				Input.Name = foundProduct.Name;
				Input.Price = foundProduct.Price;
				Input.Description = foundProduct.Description;
				Input.CategoryId = foundProduct.CategoryId;
				Input.Id = foundProduct.Id;
				ProductExists = true;
			}
		}

		private async Task Update()
		{
			if(await dataCategory.GetCategoryAsync(Input.CategoryId) is not null){
				Input.Id = Id;
				if (await data.UpdateProductAsync(Input))
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
