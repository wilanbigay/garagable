﻿using System.Linq;
using System.Web.Http.Filters;

namespace Garagable.Web.Infrastructure
{
    public class EnableCorsAttribute : ActionFilterAttribute
    {
        const string Origin = "Origin";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {
            if (actionExecutedContext.Request.Headers.Contains(Origin)) {
                string originHeader = actionExecutedContext.Request.Headers.GetValues(Origin).FirstOrDefault();
                if (!string.IsNullOrEmpty(originHeader)) {
                    actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, originHeader);
                }
            }
        }
    }
}