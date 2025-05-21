using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM.Extensions;

public static class QueryableSortExtensions
{
    private static readonly ConcurrentDictionary<Type, object> CacheSortHolders = new();

    public static async Task<PaginatedResult<T>> Paginate<T>(
        this IQueryable<T> queryable,
        IPagedBase pagedBase)
    {
        var pageSize = pagedBase._size < 0 ? 0 : pagedBase._size;
        var currentPage = pagedBase._page < 0 ? 0 : pagedBase._page;
        var skip = (currentPage * pageSize) ?? 0;
        var take = (int)pagedBase._size;

        var totalCount = await queryable.CountAsync();

        var results = await queryable
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return new PaginatedResult<T>
        {
            TotalItems = totalCount,
            Data = results.AsReadOnly<T>(),
            CurrentPage = (int)currentPage,
            PageSize = (int)pageSize
        };
    }

    public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, string? order)
    {
        var orders = order?
            .ToUpper()
            .Split([','], StringSplitOptions.RemoveEmptyEntries)
            ?? [];

        if (orders.Length <= 0)
            return queryable;

        var type = typeof(T);

        var holder = CacheSortHolders.GetOrAdd(type, _ => new SortCacheHolder<T>()) as SortCacheHolder<T>;

        if (holder == null)
            return queryable;

        IOrderedQueryable<T>? orderedQueryable = null;
        var first = true;

        foreach (var x in orders)
        {
            if (string.IsNullOrWhiteSpace(x))
                continue;

            var selectorKey = x
                .Replace("DESC", "", StringComparison.OrdinalIgnoreCase)
                .Replace("ASC", "", StringComparison.OrdinalIgnoreCase)
                .Trim();

            var accessorExpr = holder
                .Cache
                .GetOrAdd(selectorKey, new Lazy<Expression<Func<T, object?>>>(() =>
                {
                    return CreatePropertyAccessor<T>(holder.ParameterExpr, selectorKey);
                })).Value;

            if (first)
            {
                orderedQueryable = x.Contains("DESC", StringComparison.OrdinalIgnoreCase)
                    ? queryable.OrderByDescending(accessorExpr)
                    : queryable.OrderBy(accessorExpr);

                first = false;
            }
            else
            {
                orderedQueryable = x.Contains("DESC", StringComparison.OrdinalIgnoreCase)
                    ? orderedQueryable!.ThenByDescending(accessorExpr)
                    : orderedQueryable!.ThenBy(accessorExpr);
            }
        }

        return orderedQueryable ?? queryable;
    }

    private static Expression<Func<T, object?>> CreatePropertyAccessor<T>(ParameterExpression param, string propertyPath)
    {
        Expression body = param;
        foreach (var prop in propertyPath.Split('.'))
        {
            var propInfo = body.Type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                ?? throw new ArgumentException($"Property '{prop}' not found in type '{body.Type.Name}'");

            body = Expression.Property(body, propInfo);
        }

        var converted = Expression.Convert(body, typeof(object));
        return Expression.Lambda<Func<T, object?>>(converted, param);
    }
}

internal class SortCacheHolder<T>
{
    public ParameterExpression ParameterExpr { get; } = Expression.Parameter(typeof(T), "x");

    public ConcurrentDictionary<string, Lazy<Expression<Func<T, object?>>>> Cache { get; } = new();
}
