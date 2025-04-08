using BilbolStack.Boonamai.P2ERPG.Business.Managers.Security;
using BilbolStack.Boonamai.P2ERPG.Common.Constants;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BilbolStack.Boonamai.P2ERPG.Api.Filters
{
    public class AuthorizedAccountFilter : IActionFilter
    {
        private readonly ISecurityManager _securityManager;
        public AuthorizedAccountFilter(ISecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var signature = context.HttpContext.Request.Headers[Headers.AUTHORIZATION].FirstOrDefault()?.Split(" ").Last();
            var account = context.HttpContext.Request.Headers[Headers.WALLET].FirstOrDefault();
            _securityManager.AssertAccess(account, signature).GetAwaiter().GetResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
