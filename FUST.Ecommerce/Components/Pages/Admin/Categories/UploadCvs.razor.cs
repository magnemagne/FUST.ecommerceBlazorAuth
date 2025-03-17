using FUST.Ecommerce.Models;
using FUST.Ecommerce.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace FUST.Ecommerce.Components.Pages.Admin.Categories
{
	public partial class UploadCvs(ICategoryCsvService cvsData, ICategoryDataAccess data)
	{
		public string Status;

		public IBrowserFile FileInput { get; set; }

		private async Task Upload(InputFileChangeEventArgs e)
		{
			using var streamReader = new StreamReader(e.File.OpenReadStream());
			var text = await streamReader.ReadToEndAsync();
			
			IEnumerable<Category> categories = await cvsData.convertCvsToProductList(text);
			await data.AddCategoriesAsync(categories);

			
		}

	}
}
