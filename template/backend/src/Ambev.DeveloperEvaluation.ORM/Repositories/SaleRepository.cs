using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of SaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;


    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context"></param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Sale> CreateAsync(Sale product, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => 
        await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Sales.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Lists all sales in the database
    /// </summary>
    /// <param name="pagedOrdered"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PaginatedResult<Sale>> ListSalesAsync(PagedOrderedBase pagedOrdered, CancellationToken cancellationToken = default) =>
        await _context
            .Sales
            .AsNoTracking()
            .Sort(pagedOrdered._order)
            .Paginate(pagedOrdered, cancellationToken);

    /// <summary>
    /// Retrieves the last sale number
    /// </summary>
    /// <returns></returns>
    public async Task<long> GetLastSaleNumber() =>
        await _context
            .Sales
            .AsNoTracking()
            .Select(x => x.Number)
            .OrderByDescending(x => x)
            .FirstOrDefaultAsync();
}
