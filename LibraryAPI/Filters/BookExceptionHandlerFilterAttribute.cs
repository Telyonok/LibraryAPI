using FluentValidation;
using LibraryAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text;

namespace LibraryAPI.Filters
{
    public class BookExceptionHandlerFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            StringBuilder messageBuilder = new StringBuilder();
            if (exception is ValidationException)
                BuildValidationExceptionMessage(messageBuilder, (ValidationException)filterContext.Exception);
            else if (exception is EntityAlreadyExistsException || exception is EntityNotFoundException)
                messageBuilder.Append(exception.Message);
            else
                messageBuilder.Append(Helpers.Constants.UnknownMessage);
            filterContext.Result = new ObjectResult(messageBuilder.ToString())
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
            };
            filterContext.ExceptionHandled = true;
        }

        private static void BuildValidationExceptionMessage(StringBuilder messageBuilder, ValidationException validationException)
        {
            messageBuilder.AppendLine(Helpers.Constants.BookInvalidMessage);
            foreach (var error in validationException.Errors)
            {
                messageBuilder.AppendLine(error.ErrorMessage);
            }
        }
    }
}
