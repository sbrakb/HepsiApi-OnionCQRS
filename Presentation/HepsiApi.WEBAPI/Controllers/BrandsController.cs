using HepsiApi.Application.Features.Brands.Commands.CreateBrand;
using HepsiApi.Application.Features.Brands.Queries.GetAllBrands;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.WEBAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BrandsController : ControllerBase
{
  private readonly IMediator _mediator;
  public BrandsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  public async Task<IActionResult> Create1000000Brand(CreateBrandCommandRequest request)
  {
    await _mediator.Send(request);
    return Ok();
  }

  [HttpGet]
  public async Task<IActionResult> GetAllBrandsWithRedis()
  {
    var response = await _mediator.Send(new GetAllBrandsQueryRequest());
    return Ok(response);
  }
}

