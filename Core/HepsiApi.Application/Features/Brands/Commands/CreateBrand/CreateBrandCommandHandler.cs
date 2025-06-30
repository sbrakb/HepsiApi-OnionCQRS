using Bogus;
using HepsiApi.Application.Bases;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiApi.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
{
  public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {
  }


  public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
  {
    Faker faker = new("tr");
    List<Brand> brands = new();

    for (int i = 0; i < 1000000; i++)
    {
      brands.Add(new(faker.Commerce.Department(1)));
    }

    await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
    await _unitOfWork.SaveAsync();

    return Unit.Value;
  }
}