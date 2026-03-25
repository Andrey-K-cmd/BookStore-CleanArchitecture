namespace Infrastructure.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublishingHouse { get; set; } = string.Empty;
        public int PublishingYear { get; set; }
        public int CountPages { get; set; }
        public decimal Price { get; set; }
        public string Binding { get; set; } = string.Empty;
    }
}
