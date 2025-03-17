using Dapper;
using FUST.Ecommerce.Models;
using MySqlConnector;

namespace FUST.Ecommerce.Services
{
	public class ProductDataAccess : IProductDataAccess
	{
		private string _connectionString;
		private ILogger<ProductDataAccess> _logger;

		public ProductDataAccess(IConfiguration configuration,
								  ILogger<ProductDataAccess> logger)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection")
				?? throw new Exception("ConnectionString 'DefaultConnection' not found.");
			_logger = logger;
		}
		public async Task<bool> AddProductAsync(Product product)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            INSERT INTO products (name, price, categoryId, description)
            VALUES (@Name, @Price, @CategoryId, @Description);
            SELECT last_insert_id();
            """;
			try
			{
				product.Id = await connection.ExecuteScalarAsync<int>(query, product);
			}
			catch (MySqlConnector.MySqlException)
			{
				return false;
			}
			return true;
		}

		public async Task<bool> DeleteProductAsync(int id)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
				DELETE FROM products
				WHERE
					Id = @id;
				""";
			var result = await connection.ExecuteAsync(query, new { id });
			return result > 0;
		}

		public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            SELECT 
                p.id, p.name, price, categoryId, description, c.name as categoryName
            FROM products p
                inner join categories c on p.categoryId = c.id;
            """;
			return await connection.QueryAsync<ProductViewModel>(query);
		}

		public async Task<ProductViewModel?> GetProductAsync(int id)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            SELECT 
                p.id, p.name, price, categoryId, description, c.name as categoryName
            FROM products p
                inner join categories c on p.categoryId = c.id
            WHERE p.id = @Id;
            """;
			return await connection.QueryFirstOrDefaultAsync<ProductViewModel>(query, new { id });
		}

		public async Task<bool> UpdateProductAsync(Product product)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
				UPDATE products
				SET
					name = @Name, price = @Price, categoryId = @CategoryId, description = @Description
				WHERE
					id = @Id;
				""";
			return await connection.ExecuteAsync(query, product) == 1 ? true : false;
		}
	}
}
