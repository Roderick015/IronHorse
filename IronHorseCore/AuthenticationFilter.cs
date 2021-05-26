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
            ////#if DEBUG
            context.HttpContext.Session.SetInt32("UserId", 1);
            context.HttpContext.Session.SetString("UserName", "Roderick");
            ////            context.HttpContext.Session.SetString("CryptKey", "Roderick");
            ////#else
            //var path = context.HttpContext.Request.Path;

            //List<String> path_anonymus = new List<string>();
            //path_anonymus.Add("/Login");
            //path_anonymus.Add("/Salir");
            //path_anonymus.Add("/ConfrimacioDeCorreo");
            //path_anonymus.Add("/RecuperarContrasena");
            //path_anonymus.Add("/Registro");
            ////path_anonymus.Add("/Error/");
            //path_anonymus.Add("/get-captcha-image");
            //path_anonymus.Add("/Home/Error");

            //String anonymus = path_anonymus.Where(m => m.Equals(path)).FirstOrDefault();// || m.Contains(path)
            //if (anonymus == null)
            //{
            //    if (String.IsNullOrEmpty(context.HttpContext.Session.GetString("UserId")))
            //    {
            //        context.Result = new RedirectToRouteResult(
            //                    new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            //    }
            //}
            ////#endif
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
