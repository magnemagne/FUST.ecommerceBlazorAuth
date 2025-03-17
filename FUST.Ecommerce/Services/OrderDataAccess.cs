using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public class OrderDataAccess : IOrderDataAccess
	{
		public Task<bool> AddOrderAsync(Order order)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteOrderAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Order?> GetOrderAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Order>> GetOrdersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateOrderAsync(Order order)
		{
			throw new NotImplementedException();
		}
	}
}
