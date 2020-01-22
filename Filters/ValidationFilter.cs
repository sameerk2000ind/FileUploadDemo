using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadDemo.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new BadRequestObjectResult("OnActionExecuted : Object is null");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new BadRequestObjectResult("OnActionExecuting : Object is null");
        }
    }
}
