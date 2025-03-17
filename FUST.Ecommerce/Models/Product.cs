using Org.BouncyCastle.Utilities;
using System.ComponentModel.DataAnnotations;

namespace FUST.Ecommerce.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = "";
		public string? Description { get; set; } = "Sample description";
		[Required]
		public decimal Price { get; set; } = 99999.99M;
		[Required]
		public int CategoryId { get; set; }
	}

	public class ProductViewModel : Product
	{
		public string? CategoryName { get; set; }
	}
}
