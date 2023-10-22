using FluentValidation;

namespace MinimalAPI.Validators;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> PhoneRegex<T>(this IRuleBuilder<T, string> rule) =>
        rule.Matches(@"^(\+\d{1,4}\s?)?(\(?\d{1,}\)?[-.\s]?)+\d{1,}$")
            .WithMessage("Invalid phone number.");
    public static IRuleBuilderOptions<T, string> EmailRegex<T>(this IRuleBuilder<T, string> rule) =>
        rule.Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
            .WithMessage("Invalid email address.");
}
