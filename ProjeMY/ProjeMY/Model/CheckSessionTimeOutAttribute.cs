using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjeMY.Model
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true,AllowMultiple = false)]
    public class CheckSessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if(context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];
                    if((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET&#95;SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        string redirectTo = "~/Users/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            redirectTo = string.Format("~/Users/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
                            filterContext.Result = new RedirectResult(redirectTo);
                            return;
                        }
                        
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }   
    }
}