using HepsiApi.Application.Features.Products.Command.CreateProduct;
using HepsiApi.Application.Features.Products.Command.DeleteProducts;
using HepsiApi.Application.Features.Products.Command.UpdateProduct;
using HepsiApi.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.WEBAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
  private readonly IMediator _mediator;
  public ProductsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  [Authorize]
  public async Task<IActionResult> GetAll()
  {
    var response = await _mediator.Send(new GetAllProductsQueryRequest());
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateProductCommandRequest request)
  {
    await _mediator.Send(request);
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> Update(UpdateProductCommandRequest request)
  {
    await _mediator.Send(request);
    return Ok(request);
  }

  [HttpDelete]
  public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
  {
    await _mediator.Send(request);
    return Ok(request);
  }
}