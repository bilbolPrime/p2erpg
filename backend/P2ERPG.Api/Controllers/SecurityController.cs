using BilbolStack.Boonamai.P2ERPG.Api.Filters;
using BilbolStack.Boonamai.P2ERPG.Api.Models.Requests.Security;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Security;
using BilbolStack.Boonamai.P2ERPG.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("security")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityManager _securityManager;
        public SecurityController(ISecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        [HttpGet("challenge")]
        public async Task<object> Challenge([Required][FromHeader(Name = Headers.WALLET)] string wallet) 
        { 
            var challenge = await _securityManager.GetChallenge(wallet);
            return new { challenge };
        }

        [HttpPost("signin")]
        public async Task<object> Signin([Required][FromHeader(Name = Headers.WALLET)] string wallet, [FromBody] SignInRequest signInRequest)
        {
            var token = await _securityManager.SignIn(wallet, signInRequest.Signature);
            return new { token };
        }

        [HttpGet("test")]
        [ServiceFilter(typeof(AuthorizedAccountFilter))]
        public string Test([Required][FromHeader(Name = Headers.WALLET)] string wallet)
        {
            return "success";
        }
        
    }
}
