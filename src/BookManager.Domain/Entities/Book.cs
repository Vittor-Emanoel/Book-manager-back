using Book_manager.src.BookManager.Domain.Enums;

namespace Book_manager.src.BookManager.Domain.entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int Rating { get; set; }
        public BookStatus Status { get; set; }
        public string? Description { get; set; }
    }
}

