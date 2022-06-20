using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Filters
{
  public class LogAction : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var routeData = filterContext.RouteData;
      var controllerName = routeData.Values["controller"];
      var actionName = routeData.Values["action"];
      var message = string.Format("ActionExecuting - Controller: {0}, Action: {1}", controllerName, actionName);
      System.Diagnostics.Debug.WriteLine(message);
    }
  }
}
