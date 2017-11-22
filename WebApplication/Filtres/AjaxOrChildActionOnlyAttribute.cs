using System;
using System.Web.Mvc;

namespace WebApplication.Filtres
{
    public class AjaxOrChildActionOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (!((filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest") ||
               (filterContext.IsChildAction)))
                filterContext.Result = new HttpNotFoundResult();
        }
    }
}