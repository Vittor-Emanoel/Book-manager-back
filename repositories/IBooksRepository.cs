using Book_manager.Models;

namespace Book_manager.Repository;

public interface IBooksRepository
{
  Task<IEnumerable<Book>> GetAll();
  Task<int> CreateAsync(Book item);
}