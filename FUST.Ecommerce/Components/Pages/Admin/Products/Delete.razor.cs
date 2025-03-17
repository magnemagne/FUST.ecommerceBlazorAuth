using FUST.Ecommerce.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using FUST.Ecommerce.Services;

namespace FUST.Ecommerce.Components.Pages.Admin.Products
{
	public partial class Delete(IProductDataAccess data, UserManager<ApplicationUser> UserManager)
	{
		private bool? _operationStatus;

		private string ButtonText = "Undo";

		[CascadingParameter]
		public Task<AuthenticationState>? AuthState { get; set; }
		[Parameter]
		public int Id { get; set; }

		protected async override Task OnInitializedAsync()
		{
			var state = await AuthState;
			var user = state.User;
		}

		protected async Task DeleteProduct()
		{
			ButtonText = "Go back to list";
			_operationStatus = await data.DeleteProductAsync(Id);
		}
	}

}
