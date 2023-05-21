using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Behavior
{
    public class ValidationBehaviour<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse> where IRequest : IRequest<IResponse>
    {
        private IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<IRequest>> validators) { 
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        
        }
        public async Task<IResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResponse> next)
        {
            if (_validators.Any())
            {
                var context =  new ValidationContext<IRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList(); // fetches for failures
                if (failures.Count != 0) // failiures found
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
