using FluentValidation;

namespace HepsiApi.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
{
  public RefreshTokenCommandValidator()
  {
    RuleFor(x => x.AccessToken).NotEmpty();

    RuleFor(x => x.RefreshToken).NotEmpty();
  }
}
