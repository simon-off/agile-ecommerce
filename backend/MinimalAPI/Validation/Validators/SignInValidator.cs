using FluentValidation;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Validation.Validators;

public class SignInValidator : AbstractValidator<SignInDTO>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email).NotEmpty().Length(6, 320).EmailRegex();
        RuleFor(x => x.Password).NotEmpty();
    }
}