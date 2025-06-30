using HepsiApi.Application.Bases;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiApi.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest>
{
  public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {

  }
  public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
  {
    // Product product = await _unitOfWork.GetReadRepository<Product>().GetAsync(expPredicate: p => p.Id == request.Id && !p.IsDeleted);

    var product = _mapper.Map<Product, UpdateProductCommandRequest>(request);

    var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(pc => pc.ProductId == request.Id);

    await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

    foreach (var categoryId in request.CategoryIds)
    {
      await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
      {
        ProductId = request.Id,
        CategoryId = categoryId
      });
    }

    await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
    await _unitOfWork.SaveAsync();

  }
}


