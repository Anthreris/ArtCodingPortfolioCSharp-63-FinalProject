using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArtAndCodingPortfolio.Filters;

public class AdminOnlyAttribute : ActionFilterAttribute 
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var session = context.HttpContext.Session.GetString("IsAdmin");
        if (session != "True")
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}