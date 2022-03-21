using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;

namespace Store.BusinessLogic.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResponseBase, new() where TRequest : IRequest<TResponse>
    {
        private readonly IValidationHandler<TRequest> _validationHandler;

        // Have 2 constructors incase the validator does not exist
        public ValidationBehaviour()
        {

        }

        public ValidationBehaviour(IValidationHandler<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            if (_validationHandler == null)
            {
                return await next();
            }

            var result = await _validationHandler.Validate(request);
            if (!result.IsSuccessful)
            {
                return new TResponse { StatusCode = HttpStatusCode.BadRequest, ErrorMessage = result.Error };
            }

            return await next();
        }
    }
}
