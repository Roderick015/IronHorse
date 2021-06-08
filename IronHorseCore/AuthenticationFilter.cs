using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IronHorseCore
{
    public class AuthenticationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //#if DEBUG
            
            //context.HttpContext.Session.SetInt32("UserId", 1);
            //context.HttpContext.Session.SetString("UserName", "Gustavo");
            
            //#else
            var path = context.HttpContext.Request.Path;

            List<String> path_anonymus = new List<string>();
            path_anonymus.Add("/Login");
            path_anonymus.Add("/Logout");

            String anonymus = path_anonymus.Where(m => m.Equals(path)).FirstOrDefault();// || m.Contains(path)
            if (anonymus == null)
            {
                if (String.IsNullOrEmpty(context.HttpContext.Session.GetString("UserId")))
                {
                    context.Result = new RedirectToRouteResult(
                                new RouteValueDictionary(new { controller = "Home", action = "Login" }));
                }
            }
            //#endif
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

}