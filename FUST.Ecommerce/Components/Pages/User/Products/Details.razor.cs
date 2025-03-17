using FUST.Ecommerce.Models;
using FUST.Ecommerce.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FUST.Ecommerce.Components.Pages.User.Products
{
	public partial class Details(IProductDataAccess data)
	{
		[Parameter]
		public int Id { get; set; }

		public ProductViewModel? foundProduct;

		public bool HasProductBeenFound = false;

		protected async override Task OnInitializedAsync()
		{
			foundProduct = await data.GetProductAsync(Id);
			if (foundProduct is not null)
			{
				HasProductBeenFound = true;
			}
		}
	}
}
