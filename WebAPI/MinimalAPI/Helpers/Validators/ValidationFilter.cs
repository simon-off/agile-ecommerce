using FluentValidation;

namespace MinimalAPI.Helpers.Validators;

// TODO: UNDERSTAND THIS STUFF...
public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
        var entity = context.Arguments.OfType<T>().FirstOrDefault(a => a?.GetType() == typeof(T));

        if (validator is not null && entity is not null)
        {
            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return TypedResults.ValidationProblem(validationResult.ToDictionary());
            }
        }
        else
        {
            return TypedResults.Problem("Could not find type to validate");
        }

        return await next.Invoke(context);
    }
}