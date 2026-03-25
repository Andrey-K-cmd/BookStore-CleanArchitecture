namespace Application.Contracts.Store
{
    public record BookRequest(
        string Title,
        string Author,
        string PublishingHouse,
        int PublishingYear,
        int CountPages,
        decimal Price,
        string Binding);
}
