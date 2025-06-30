using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Auth.Exceptions;

public class EmailAddressShouldBeValidException : BaseException
{
  public EmailAddressShouldBeValidException() : base("Email hatalı")
  {

  }
}
