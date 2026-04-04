namespace Application.Contracts.Store
{
    public record BookFilterRequest(
        string? Title,
        string? Author,
        decimal? MinPrice,
        string? Binding);
}
