using System.Web.Mvc;
using System.Web.Routing;

namespace Fenit.Toolbox.ApplicationUserManager.Attributes
{
    public class OnlyAnonimAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "Index"}
                    });
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}