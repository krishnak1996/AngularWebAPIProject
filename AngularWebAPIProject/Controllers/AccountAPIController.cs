using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly IAccount account;
        public AccountAPIController(IAccount account)
        {
            this.account = account;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = account.Login(loginModel);
                return Ok(responseModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
