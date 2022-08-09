using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Controllers
{
    public class ControllerBase : Controller
    {
        /// <summary>
        /// The logger instance, accessable from all deriving classes
        /// </summary>
        protected ILogger logger { get; private set; }

        /// <summary>
        /// Small override to automatically log the exeuction of an action.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var action = context.ActionDescriptor.RouteValues["action"].ToString();
            var controller = context.ActionDescriptor.RouteValues["controller"].ToString();
            logger = logger
                .ForContext("ReqId", context.HttpContext.TraceIdentifier)
                .ForContext("Controller", controller)
                .ForContext("Action", action);
            return base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="logger">The logger to use for the action.  Also sets the context's "PrincipalName" to the FriendlyName of the AuthPrincipal.</param>
        public ControllerBase(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
