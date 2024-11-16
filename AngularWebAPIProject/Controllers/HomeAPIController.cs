using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL.Migrations;
using AngularWebAPIProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private readonly IHome home;
        public HomeAPIController(IHome home)
        {
            this.home = home;
        }

        /// <summary>
        /// Get Transactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = home.GetTransactions();
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
