namespace Core.Models
{
    public record BookFilter(
        string? Title,
        string? Author,
        decimal? MinPrice,
        string? Binding);
}
