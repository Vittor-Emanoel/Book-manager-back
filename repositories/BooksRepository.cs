using Book_manager.Models;
using Npgsql;
using Microsoft.Extensions.Configuration;

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

  public Task<int> Create(Book item)
  {
    using (var dbConnection = new NpgsqlConnection(_connectionString))
    {
      var query = $"In";

      return Task.FromResult(1);
    }

  }
}