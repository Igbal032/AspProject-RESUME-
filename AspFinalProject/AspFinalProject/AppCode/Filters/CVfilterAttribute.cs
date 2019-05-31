using AspFinalProject.AppCode.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspFinalProject
{
    public class CVfilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {

                return;
            }

            if (filterContext.HttpContext.Session[SessionKey.Admin]==null)
            {
                filterContext.Result = new RedirectResult("LoginPart");
            }
        }

    }
}