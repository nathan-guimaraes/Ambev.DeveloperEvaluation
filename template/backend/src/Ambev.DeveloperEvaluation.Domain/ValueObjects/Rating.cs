namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public record Rating
{
    public decimal Rate { get; set; }
    public int Count { get; set; }
}