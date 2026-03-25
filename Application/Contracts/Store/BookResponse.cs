namespace Application.Contracts.Store
{
    public record BookResponse(
        Guid Id,
        string Title,
        string Author,
        string PublishingHouse,
        int PublishingYear,
        int CountPages,
        decimal Price,
        string Binding);
}
