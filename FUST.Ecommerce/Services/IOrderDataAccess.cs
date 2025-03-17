using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public interface IOrderDataAccess
	{
		Task<bool> AddOrderAsync(Order order);
		Task<Order?> GetOrderAsync(int id);
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<bool> UpdateOrderAsync(Order order);
		Task<bool> DeleteOrderAsync(int id);
	}
}
