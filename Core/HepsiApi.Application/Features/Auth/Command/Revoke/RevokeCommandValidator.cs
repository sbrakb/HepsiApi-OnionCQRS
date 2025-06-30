using FluentValidation;

namespace HepsiApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
{
  public RevokeCommandValidator()
  {
    RuleFor(x => x.Email)
        .EmailAddress()
        .NotEmpty();
  }
}