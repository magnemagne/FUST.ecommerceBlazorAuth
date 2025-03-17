using FUST.Ecommerce.Models;

namespace FUST.Ecommerce.Services
{
	public interface ICategoryCsvService
	{
		Task<IEnumerable<Category>> convertCsvToCategoryList(String csv);

	}
}
