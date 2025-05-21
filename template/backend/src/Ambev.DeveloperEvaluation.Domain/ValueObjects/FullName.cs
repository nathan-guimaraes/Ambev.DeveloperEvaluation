namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public sealed record FullName
{
    public string Firstname { get; init; } = string.Empty;
    public string Lastname { get; init; } = string.Empty;

    public FullName(string fullName)
    {
        var splitted = SplitFullName(fullName);
        this.Firstname = ExtractFirstName(splitted);
        this.Lastname = ExtractLastName(splitted);
    }

    private static string ExtractFirstName(string[] fullName) =>
        fullName.Length > 0 ? fullName[0] : string.Empty;

    private static string ExtractLastName(string[] fullName) =>
        fullName.Length > 1 ? fullName[^1] : string.Empty;

    private static string[] SplitFullName(string fullName) =>
        fullName
        .Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
