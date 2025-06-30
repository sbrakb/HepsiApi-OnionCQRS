using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.WEBAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  public ValuesController(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
    return Ok(result);
  }
}

