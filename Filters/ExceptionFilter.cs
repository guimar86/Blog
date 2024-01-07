using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorDetails = new ErrorDetails
        {
            StatusCode = "500",
            Message = context.Exception.Message
        };

        context.Result = new JsonResult(errorDetails) { StatusCode = 500 };
    }
}