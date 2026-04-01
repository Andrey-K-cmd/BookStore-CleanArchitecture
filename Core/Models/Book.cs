namespace Core.Models
{
    public class Book
    {
        public const int MAX_LENGTH = 250;

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Author { get; } = string.Empty;
        public string PublishingHouse { get; } = string.Empty;
        public int PublishingYear { get; }
        public int CountPages { get; }
        public decimal Price { get; }
        public string Binding { get; } = string.Empty;

        private Book(Guid id, string title, string author, 
            string publishingHouse, int publishingYear, 
            int countPages, decimal price, string binding)
        {
            Id = id;
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
            PublishingYear = publishingYear;
            CountPages = countPages;
            Price = price;
            Binding = binding;
        }

        public static Book Create(Guid id, string title, string author,
            string publishingHouse, int publishingYear,
            int countPages, decimal price, string binding)
        {

            return new Book(id, title, author, publishingHouse, publishingYear, countPages, price, binding);
        }
    }
}
