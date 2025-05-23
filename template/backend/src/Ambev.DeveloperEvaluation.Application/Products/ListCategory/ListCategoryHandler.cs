using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;


public class ListCategoryHandler : IRequestHandler<ListCategoryCommand, string[]>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListCategoryHandler(
        IProductRepository userRepository,
        IMapper mapper)
    {
        _productRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string[]> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.ListCategoryAsync(cancellationToken);
    }
}
