using System.ComponentModel.DataAnnotations;

namespace FUST.Ecommerce.Models
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		public int ProductId { get; set; }
		[Required]
		public string UserId { get; set; }
		[Required]	
		public int Quantity { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public DateTime? DeliverDate { get; set; }
	}
}
