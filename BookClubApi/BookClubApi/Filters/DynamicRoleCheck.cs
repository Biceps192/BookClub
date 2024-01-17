using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookClubApi.Data;

namespace BookClubApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DynamicRoleCheckAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string[] _requiredRoles;

        public DynamicRoleCheckAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
      
                var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

              
                var dbContext = context.HttpContext.RequestServices.GetRequiredService<BookContext>();
                var userRoles = dbContext.UserRoles
                    .Where(ur => ur.UserId == int.Parse(userId))
                    .Select(ur => ur.Role.Name)
                    .ToList();

        
                if (_requiredRoles.Any(requiredRole => userRoles.Contains(requiredRole)))
                {
   
                    await next();
                    return;
                }

                 
                context.Result = new ForbidResult();
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
