using System.Security.Claims;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace HepsiApi.Application.Bases;

public class BaseHandler
{

  public readonly IUnitOfWork _unitOfWork;
  public readonly IMapper _mapper;
  public readonly IHttpContextAccessor _httpContextAccessor;
  public readonly string _userId;

  public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _httpContextAccessor = httpContextAccessor;
    _userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
  }
}