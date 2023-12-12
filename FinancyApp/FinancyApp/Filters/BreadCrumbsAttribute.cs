using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancyApp.Filters;

public class BreadcrumbAttribute : ActionFilterAttribute
{
    public string Title { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.Controller as Controller;
        if (controller != null)
        {
            controller.ViewBag.Breadcrumb = Title;
        }
        base.OnActionExecuting(context);
    }
}

