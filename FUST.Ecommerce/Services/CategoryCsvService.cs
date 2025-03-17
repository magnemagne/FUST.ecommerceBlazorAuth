using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public class CategoryCsvService : ICategoryCsvService
	{
		public Task<IEnumerable<Category>> convertCsvToCategoryList(string csv)
		{
			var list = new List<Category>();
			var lines = csv.Split(Environment.NewLine).ToList();
			lines.RemoveAt(0);
			foreach (var item in lines)
			{
				var values = item.Split(",");
				var category = new Category();
				category.Name = values[0];
				list.Add(category);
			}

			return Task.FromResult((IEnumerable<Category>)list);
		}
	}
}
