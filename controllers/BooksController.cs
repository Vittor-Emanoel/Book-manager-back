using Microsoft.AspNetCore.Mvc;

namespace Book_manager.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {

    [HttpGet]
    public async Task GetAll()
    {

    }

  }
}