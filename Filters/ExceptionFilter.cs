using System.Net;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "An error occured while processing your request",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = context.Exception.Message
        };


        context.Result = new JsonResult(problemDetails);
    }
}