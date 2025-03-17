using CsvHelper.Configuration.Attributes;
using Org.BouncyCastle.Utilities;
using System.ComponentModel.DataAnnotations;

namespace FUST.Ecommerce.Models
{
	public class Product
	{
		[Name("id")]
		public int Id { get; set; }
		[Required]
		[Name("name")]
		public string Name { get; set; } = "";
		[Name("description")]
		public string? Description { get; set; } = "Sample description";
		[Required]
		[Name("price")]
		public decimal Price { get; set; } = 99999.99M;
		[Required]
		[Name("categoryid")]
		public int CategoryId { get; set; }
	}

	public class ProductViewModel : Product
	{
		public string? CategoryName { get; set; }
	}
}
