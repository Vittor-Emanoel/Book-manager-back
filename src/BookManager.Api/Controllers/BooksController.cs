using Book_manager.src.BookManager.Application.Services.Books.Command.CreateBook;
using Book_manager.src.BookManager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_manager.src.BookManager.Api.controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IMediator _mediator;

        public BooksController(IBookRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

    }
}