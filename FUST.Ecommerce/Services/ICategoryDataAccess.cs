using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public interface ICategoryDataAccess
	{
		Task<bool> AddCategoryAsync(Category category);
		Task<Category?> GetCategoryAsync(int id);
		Task<IEnumerable<Category>> GetCategoriesAsync();
		Task<bool> UpdateCategoryAsync(Category category);
		Task<bool> DeleteCategoryAsync(int id);
	}
}
