using HepsiApi.Application.Bases;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiApi.Application.Features.Products.Command.DeleteProducts;

public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest>
{
  public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {

  }


  public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
  {
    Product product = await _unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id && !p.IsDeleted);
    product.IsDeleted = true;
    await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
    await _unitOfWork.SaveAsync();
  }
}
