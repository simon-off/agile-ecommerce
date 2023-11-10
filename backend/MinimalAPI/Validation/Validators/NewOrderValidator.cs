using FluentValidation;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Validation.Validators;

public class NewOrderValidator : AbstractValidator<OrderCreateDTO>
{
    public NewOrderValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().Length(2, 100);
        RuleFor(x => x.LastName).NotEmpty().Length(2, 100);
        RuleFor(x => x.Email).NotEmpty().Length(6, 320).EmailRegex();
        RuleFor(x => x.PhoneNumber).NotEmpty().Length(10, 20).PhoneRegex();
        RuleFor(x => x.StreetAddress).NotEmpty().Length(1, 255);
        RuleFor(x => x.PostalCode).NotEmpty().Length(4, 20);
        RuleFor(x => x.City).NotEmpty().Length(1, 255);
        RuleFor(x => x.Items).NotEmpty();
    }
}