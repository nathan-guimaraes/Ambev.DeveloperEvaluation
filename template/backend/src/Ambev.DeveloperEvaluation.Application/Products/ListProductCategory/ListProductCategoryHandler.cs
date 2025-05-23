using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategory;

public class ListProductCategoryHandler : IRequestHandler<ListProductCategoryCommand, ListProductResult>
{
    private readonly IProductRepository _userRepository;
    private readonly IMapper _mapper;

    public ListProductCategoryHandler(
        IProductRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ListProductResult> Handle(ListProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var products = await _userRepository.ListProductCategoryAsync(request.Category, request, cancellationToken);

        return _mapper.Map<ListProductResult>(products);
    }
}
