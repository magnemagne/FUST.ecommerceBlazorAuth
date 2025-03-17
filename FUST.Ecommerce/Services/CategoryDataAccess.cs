using Dapper;
using FUST.Ecommerce.Models;
using MySqlConnector;

namespace FUST.Ecommerce.Services
{
	public class CategoryDataAccess : ICategoryDataAccess
	{
		private string _connectionString;
		private ILogger<CategoryDataAccess> _logger;

		public CategoryDataAccess(IConfiguration configuration,
								  ILogger<CategoryDataAccess> logger)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection")
				?? throw new Exception("ConnectionString 'DefaultConnection' not found.");
			_logger = logger;
		}

		public async Task AddCategoriesAsync(IEnumerable<Category> categories)
		{
			using var connection = new MySqlConnection(_connectionString);
			await connection.OpenAsync();
			const string query = """
            INSERT INTO categories (name)
            VALUES (@Name);
            """;

			MySqlTransaction transc = connection.BeginTransaction();

			int rowsAffected = await connection.ExecuteAsync(query,
											   categories,
											   transaction: transc);
			transc.Commit();
		}

		public async Task<bool> AddCategoryAsync(Category category)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            INSERT INTO categories (name)
            VALUES (@Name);
            SELECT last_insert_id();
            """;
			try
			{
				category.Id = await connection.ExecuteScalarAsync<int>(query, category);
			}
			catch (MySqlConnector.MySqlException)
			{
				return false;
			}
			return true;
		}

		public async Task<bool> DeleteCategoryAsync(int id)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
				DELETE FROM categories
				WHERE
					Id = @id;
				""";
			var result = await connection.ExecuteAsync(query, new { id });
			return result > 0;
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            SELECT 
                id, 
                name
            FROM categories;
            """;
			return await connection.QueryAsync<Category>(query);
		}

		public async Task<Category?> GetCategoryAsync(int id)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
            SELECT 
                id, 
                name
            FROM categories
            WHERE id = @Id;
            """;
			return await connection.QueryFirstOrDefaultAsync<Category>(query, new { id });
		}

		public async Task<bool> UpdateCategoryAsync(Category category)
		{
			using var connection = new MySqlConnection(_connectionString);
			const string query = """
				UPDATE categories
				SET
					name = @Name
				WHERE
					id = @Id;
				""";
			return await connection.ExecuteAsync(query, category) == 1 ? true : false;
		}
	}
}
