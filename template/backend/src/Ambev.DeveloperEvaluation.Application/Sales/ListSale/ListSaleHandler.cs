using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;


public class ListSaleHandler : IRequestHandler<ListSaleCommand, ListSaleResult>
{
    private readonly ISaleRepository _userRepository;
    private readonly IMapper _mapper;

    public ListSaleHandler(
        ISaleRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ListSaleResult> Handle(ListSaleCommand request, CancellationToken cancellationToken)
    {
        var products = await _userRepository.ListSalesAsync(request, cancellationToken);

        return _mapper.Map<ListSaleResult>(products);
    }
}
