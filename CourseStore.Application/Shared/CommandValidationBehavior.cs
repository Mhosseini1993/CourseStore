using CourseStore.Application.Shared.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CourseStore.Application.Shared
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: class where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators=validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var res = _validators.Select(v => v.Validate(request)
                                               .Errors.Where(e => !string.IsNullOrEmpty(e.ErrorMessage)))
                                  .ToList();

            if (res.Any())
            {
                string msg = res.Select(ef => ef.Aggregate<ValidationFailure, string>("Errors :", (e1, e2) => e1+" "+e2.ErrorMessage))
                                .Aggregate((s1, s2) => s1+s2);

                throw new InvalidCommandException($"{msg}");
            }
            return await next();
        }
    }
}
