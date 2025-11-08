using Book_manager.Models;
using Book_manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Book_manager.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {

    private readonly IBooksRepository _repository;

    public BooksController(IBooksRepository repository) => _repository = repository;

    [HttpPost("")]
    public async Task<ActionResult<Book>> Create([FromBody] Book item)
    {

      var result = await _repository.CreateAsync(item);
      return Ok(result);
    }

  }
}