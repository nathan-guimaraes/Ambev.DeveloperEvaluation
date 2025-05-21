using System.Collections.ObjectModel;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public record PaginatedResult<T>
{
    public ReadOnlyCollection<T> Data { get; set; } = ReadOnlyCollection<T>.Empty;
    public int TotalItems { get; set; } = 0;
    public int PageSize { get; set; } = 0;
    public int CurrentPage { get; set; } = 0;
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}

public abstract record PagedOrderedBase : IPagedBase, IOrderedBase
{
    public int? _page { get; init; } = 0;
    public int? _size { get; init; } = 10;
    public string? _order { get; init; } = null;
}

public abstract record PagedBase : IPagedBase
{
    public int? _page { get; init; } = 1;
    public int? _size { get; init; } = 10;
}

public abstract record OrderedBase : IOrderedBase
{
    public string? _order { get; init; } = null;
}

public interface IPagedBase
{
    int? _page { get; }
    int? _size { get; }
}

public interface IOrderedBase
{
    string? _order { get; }
}