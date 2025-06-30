using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Products.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiApi.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
{
  private readonly ProductRules _productRules;
  public CreateProductCommandHandler(ProductRules productRules, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {
    _productRules = productRules;
  }


  public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
  {
    Product product = new(request.BrandId, request.Title, request.Description, request.Price, request.Discount);

    IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

    // if (products.Any(p => p.Title == request.Title))
    //   throw new Exception("Aynı başlıkta ürün zaten var");

    await _productRules.ProductTitleMustNotBeSame(products, request.Title);

    await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

    if (await _unitOfWork.SaveAsync() > 0)
    {
      foreach (var categoryId in request.CategoryIds)
      {
        await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(
          new()
          {
            ProductId = product.Id,
            CategoryId = categoryId,
          }
        );
      }
      await _unitOfWork.SaveAsync();
    }

    return Unit.Value;
  }
}