using FluentValidation;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Validation.Validators;

public class SignUpValidator : AbstractValidator<SignUpDTO>
{
    public SignUpValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().Length(2, 100);
        RuleFor(x => x.LastName).NotEmpty().Length(2, 100);
        RuleFor(x => x.Email).NotEmpty().Length(6, 320).EmailRegex();
        RuleFor(x => x.Password).NotEmpty().Length(3, 300);
    }
}