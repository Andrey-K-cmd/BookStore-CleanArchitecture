namespace Application.Contracts.Store
{
    public record BookFilterResponse(
        string? Title,
        string? Author,
        decimal? MinPrice,
        string? Binding);
}
