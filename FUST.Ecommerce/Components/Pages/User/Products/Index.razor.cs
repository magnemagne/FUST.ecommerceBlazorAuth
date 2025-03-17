using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FUST.Ecommerce.Services;
using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Components.Pages.User.Products
{
	public partial class Index(IProductDataAccess data, ICategoryDataAccess dataCategory, UserManager<ApplicationUser> UserManager)
	{
		private IEnumerable<ProductViewModel>? _products;

		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }


		protected override async Task OnInitializedAsync()
		{
			//var state = await AuthState;
			//var user = state.User;

			_products = await data.GetProductsAsync();
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
