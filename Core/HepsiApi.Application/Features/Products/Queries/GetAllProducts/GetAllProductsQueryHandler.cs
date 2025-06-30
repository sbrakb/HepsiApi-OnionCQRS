using HepsiApi.Application.DTOs;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HepsiApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  async Task<IList<GetAllProductsQueryResponse>> IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>.Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
  {
    var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(p => p.Brand));

    _mapper.Map<BrandDto, Brand>(new Brand());

    // List<GetAllProductsQueryResponse> result = new();

    // foreach (var product in products)
    // {
    //   result.Add(new GetAllProductsQueryResponse
    //   {
    //     Description = product.Description,
    //     Discount = product.Discount,
    //     Title = product.Title,
    //     Price = product.Price - (product.Price * product.Discount / 100)
    //   });
    // }

    var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
    foreach (var item in map)
      item.Price -= item.Price * item.Discount / 100;

    return map;
  }
}
