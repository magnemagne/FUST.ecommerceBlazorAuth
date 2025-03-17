using CsvHelper;
using CsvHelper.Configuration;
using FUST.Ecommerce.Models;
using System.Globalization;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace FUST.Ecommerce.Services
{
	public class ProductCsvService : IProductCsvService
	{
		public Task<IEnumerable<Product>> convertCsvToProductList(string csv)
		{
			var list = new List<Product>();
			var lines = csv.Split(Environment.NewLine).ToList();
			lines.RemoveAt(0);
			foreach (var item in lines)
			{
				var values = item.Split(",");
				var product = new Product();
				product.Name = values[0];
				product.Description = values[1];
				product.Price = decimal.Parse(values[2]);
				product.CategoryId = int.Parse(values[3]);
				list.Add(product);
			}

			return Task.FromResult((IEnumerable<Product>)list);
		}
	}
}	
