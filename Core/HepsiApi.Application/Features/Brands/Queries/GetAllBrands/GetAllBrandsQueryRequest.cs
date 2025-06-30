using HepsiApi.Application.Interfaces.RedisCache;
using MediatR;

namespace HepsiApi.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryRequest : IRequest<IList<GetAllBrandsQueryResponse>>, ICacheableQuery
{
  public string CacheKey => "GetAllBrands";

  public double CacheTime => 5;
}
