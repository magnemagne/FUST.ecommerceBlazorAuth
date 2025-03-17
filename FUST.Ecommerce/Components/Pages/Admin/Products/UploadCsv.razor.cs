using FUST.Ecommerce.Models;
using FUST.Ecommerce.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace FUST.Ecommerce.Components.Pages.Admin.Products
{
	public partial class UploadCvs(IProductCsvService cvsData, IProductDataAccess data)
	{
		public string Status;

		public IBrowserFile FileInput { get; set; }

		private async Task Upload(InputFileChangeEventArgs e)
		{
			using var streamReader = new StreamReader(e.File.OpenReadStream());
			var text = await streamReader.ReadToEndAsync();
			
			IEnumerable<Product> products = await cvsData.convertCsvToProductList(text);
			await data.AddProductsAsync(products);
		}

	}
}
