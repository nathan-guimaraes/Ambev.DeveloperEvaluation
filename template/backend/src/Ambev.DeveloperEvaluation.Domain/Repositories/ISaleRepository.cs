using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Sale> CreateAsync(Sale product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sale from the repository
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all sales in the repository
    /// </summary>
    /// <param name="pagedOrdered"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedResult<Sale>> ListSalesAsync(PagedOrderedBase pagedOrdered, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the last sale number
    /// </summary>
    /// <returns></returns>
    Task<long> GetLastSaleNumber();
}
