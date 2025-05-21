using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;


public class ListProductHandler : IRequestHandler<ListProductCommand, ListProductResult>
{
    private readonly IProductRepository _userRepository;
    private readonly IMapper _mapper;

    public ListProductHandler(
        IProductRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ListProductResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {
        //var validator = new GetProductValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    throw new ValidationException(validationResult.Errors);

        var products = await _userRepository.ListProductsAsync(request, cancellationToken);

        return _mapper.Map<ListProductResult>(products);
    }
}
