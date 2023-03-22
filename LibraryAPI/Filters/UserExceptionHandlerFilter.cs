using Library.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using Library.Domain.Helpers;

namespace LibraryAPI.Filters
{
    public class UserExceptionHandlerFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            StringBuilder messageBuilder = new StringBuilder();
            if (exception is EntityNotFoundException)
                messageBuilder.Append(exception.Message);
            else
                messageBuilder.Append(Constants.UnknownErrorMessage);
            filterContext.Result = new ObjectResult(messageBuilder.ToString())
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
            };
            filterContext.ExceptionHandled = true;
        }
    }
}
