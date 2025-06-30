using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseException
{
  public UserAlreadyExistException() : base("Kullanıcı mevcut")
  {

  }
}
