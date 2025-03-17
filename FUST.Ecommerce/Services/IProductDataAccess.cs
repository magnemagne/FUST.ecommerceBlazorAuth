using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public interface IProductDataAccess
	{
		Task<bool> AddProductAsync(Product product);
		Task<ProductViewModel?> GetProductAsync(int id);
		Task<IEnumerable<ProductViewModel>> GetProductsAsync();
		Task<bool> UpdateProductAsync(Product product);
		Task<bool> DeleteProductAsync(int id);
	}
}
