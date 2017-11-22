using System;
using System.Web;

namespace Presentation.MVC.Filters
{
   using System.Web.Mvc;

   public class HandleAllErrorAttribute : HandleErrorAttribute

   {
      public override void OnException(ExceptionContext filterContext)
      {
         if (filterContext == null)
         {
            throw new ArgumentNullException(nameof(filterContext));
         }

         // If custom errors are disabled, we need to let the normal ASP.NET exception handler
         // execute so that the user can see useful debugging information.
         if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
         {
            return;
         }

         SetErrorResultView(filterContext, filterContext.Exception);

         // Certain versions of IIS will sometimes use their own error page when
         // they detect a server error. Setting this property indicates that we
         // want it to try to render ASP.NET MVC's error page instead.
         filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

      }

      protected HandleErrorInfo SetErrorResultView(ExceptionContext filterContext, Exception exception)
      {
         string controllerName = (string)filterContext.RouteData.Values["controller"];
         string actionName = (string)filterContext.RouteData.Values["action"];

         HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
         filterContext.Result = new ViewResult
         {
            ViewName = View,
            MasterName = Master,
            ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            TempData = filterContext.Controller.TempData
         };
         filterContext.ExceptionHandled = true;
         filterContext.HttpContext.Response.Clear();
         filterContext.HttpContext.Response.StatusCode = new HttpException(null, exception).GetHttpCode();

         return model;
      }
   }


   //public class HandledErrorViewModel : HandleErrorInfo
   //{

   //   #region Public members

   //   /// <summary>
   //   /// The name of the type of the exception which is being handled.
   //   /// </summary>
   //   public string ExceptionTypeName { get; private set; }

   //   /// <summary>True if error has been logged so view itself shouldn't log it, false otherwise.</summary>
   //   public bool HasErrorBeenLogged { get; set; }

   //   public HandledErrorViewModel(Exception exception, string controllerName, string actionName)
   //       : base(exception, controllerName, actionName)
   //   {
   //      ExceptionTypeName = exception.GetType().Name;
   //   }

   //   #endregion
   //}
}