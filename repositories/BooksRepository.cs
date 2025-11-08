using Book_manager.Models;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Book_manager.Repository;

public class BooksRepository : IBooksRepository
{
  private readonly string _connectionString;

  public BooksRepository(IConfiguration configuration)
  {
    _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

  }

  public Task<IEnumerable<Book>> GetAll()
  {
    var books = new List<Book>();

    return Task.FromResult<IEnumerable<Book>>(books);
  }

  public async Task<int> CreateAsync(Book item)
  {
    using (var dbConnection = new NpgsqlConnection(_connectionString))
    {
      var query = @"INSERT INTO ""Books"" (""Name"", ""Author"", ""ImageUrl"", ""Rating"", ""Status"", ""Description"") 
                      VALUES (@Name, @Author, @ImageUrl, @Rating, @Status, @Description)";

      return await dbConnection.ExecuteAsync(query, item);
    }
  }
}