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

        public static (Book? book, string error) Create(Guid id, string title, string author,
            string publishingHouse, int publishingYear,
            int countPages, decimal price, string binding)
        {

            if (string.IsNullOrEmpty(title) || title.Length > MAX_LENGTH)
            {
                return (null, "Название книги не может быть пустым или слишком длинным");
            }
            else if (string.IsNullOrEmpty(author))
            {
                return (null, "Автор долен быть обязательно указан");
            }
            else if (publishingYear > DateTime.Now.Year)
            {
                return (null, "Такой год еще не наступил");
            }
            else if (countPages < 0)
            {
                return (null, "Кол-во страниц должно быть положительным");
            }
            else if (price < 0)
            {
                return (null, "Цена должна быть положительной");
            }

            var book = new Book(id, title, author, 
                publishingHouse, publishingYear, 
                countPages, price, binding);

            return (book, string.Empty);
        }
    }
}
