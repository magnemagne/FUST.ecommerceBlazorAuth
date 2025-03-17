using FUST.Ecommerce.Models;
using System.Collections;

namespace FUST.Ecommerce.Services
{
	public interface IProductCsvService
	{
		Task<IEnumerable<Product>> convertCsvToProductList(String csv);
	}
}
