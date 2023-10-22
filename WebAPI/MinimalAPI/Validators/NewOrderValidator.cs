using FluentValidation;
using MinimalAPI.Models.Dtos;

namespace MinimalAPI.Validators;

public class NewOrderValidator : AbstractValidator<NewOrderDto>
{
    public NewOrderValidator()
    {
        RuleFor(x => x.Address.City).NotEmpty().Length(1, 255);
        RuleFor(x => x.Address.StreetAddress).NotEmpty().Length(1, 255);
        RuleFor(x => x.Address.PostalCode).NotEmpty().Length(4, 20);
        RuleFor(x => x.Customer.FirstName).NotEmpty().Length(2, 100);
        RuleFor(x => x.Customer.LastName).NotEmpty().Length(2, 100);
        RuleFor(x => x.Customer.Email).NotEmpty().Length(6, 320).EmailRegex();
        RuleFor(x => x.Customer.PhoneNumber).NotEmpty().Length(10, 20).PhoneRegex();
        RuleFor(x => x.Items).NotEmpty();
    }
}