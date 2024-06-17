using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils.Exception
{
    public class ExceptionHandlerFilter : IExceptionFilter, IFilterMetadata
    {
        private readonly ILogger<ExceptionHandlerFilter> _logger;

        public ExceptionHandlerFilter(ILogger<ExceptionHandlerFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string message = context.Exception.InnerException != null ? context.Exception.InnerException!.Message 
                + context.Exception.InnerException.GetHashCode().ToString() : context.Exception.Message + context.Exception.GetHashCode().ToString();
            _logger.LogError("ERROR - " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
            _logger.LogError(message);
            //context.Result = new JsonResult(ExceptionHandler.CreateErrorResult(context.Exception));
            context.Result = new ObjectResult(
                    new JsonResult(ExceptionHandler.CreateErrorResult(context.Exception))
                )
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
