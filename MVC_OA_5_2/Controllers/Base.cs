using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MVCOA_5.UI.Controllers
{
    public class BaseControllers:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            base.OnActionExecuting(filterContext);
            Model.User user = Session["userinfo"] as Model.User;
            if (user==null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }
        }
    }
}