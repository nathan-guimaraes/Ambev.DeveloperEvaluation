using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateSaleHandler(
        ISaleRepository saleRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        Sale newSale = new()
        {
            UserId = command.UserId,
            Number = await GetNextSaleNumber(),
            SaleDate = DateTime.UtcNow,
            IsCanceled = false,
            Branch = command.Branch
        };

        List<SaleItem> newSaleItems = [];

        var distincsProducts = command.Items.DistinctBy(x => x.ProductId).ToList();

        foreach (var item in distincsProducts)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {item.ProductId} not found");

            var newSaleItem = new SaleItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price, 
            };

            newSaleItems.Add(newSaleItem);
        }

        newSale.Items = newSaleItems;
        newSale.ApplyDiscount();

        var createdSale = await _saleRepository.CreateAsync(newSale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }

    private async Task<long> GetNextSaleNumber()
    {
        var lastSale = await _saleRepository.GetLastSaleNumber();
        return lastSale + 1;
    }
}
