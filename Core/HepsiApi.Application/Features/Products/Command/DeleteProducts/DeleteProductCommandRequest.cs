using MediatR;

namespace HepsiApi.Application.Features.Products.Command.DeleteProducts;

public class DeleteProductCommandRequest : IRequest
{
    public int Id { get; set; }
}
