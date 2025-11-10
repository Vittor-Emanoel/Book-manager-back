using Book_manager.src.BookManager.Domain.entities;
using Book_manager.src.BookManager.Domain.Interfaces;
using MediatR;
using Book_manager.src.BookManager.Application.Common.Responses;

namespace Book_manager.src.BookManager.Application.Services.Books.Command.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, CommandResponse>
    {
        private readonly IBookRepository _booksRepository;

        public CreateBookHandler(IBookRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<CommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToSave = new Book
            {
                Name = request.Name,
                Author = request.Author,
                ImageUrl = request.ImageUrl,
                Rating = request.Rating,
                Status = request.Status,
                Description = request.Description
            };

            var success = await _booksRepository.SaveAsync(bookToSave);

            if (!success)
            {
                return new CommandResponse { Success = false, Message = "Falha ao criar o livro." };
            }

            return new CommandResponse
            {
                Success = true,
                Message = "Livro criado com sucesso."
            };
        }
    }

}