using System.ComponentModel.DataAnnotations;

namespace FUST.Ecommerce.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = "";
		public override string ToString()
		{
			return Name;
		}
	}
}
