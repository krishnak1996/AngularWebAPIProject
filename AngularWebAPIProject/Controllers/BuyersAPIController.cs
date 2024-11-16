using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuyersAPIController : ControllerBase
    {
        private readonly IBuyers buyers;
        public BuyersAPIController(IBuyers buyers)
        {
            this.buyers = buyers;
        }

        /// <summary>
        ///Get Buyers By PFID
        /// </summary>
        /// <param name="PFID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBuyersByPFID(int PFID)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = buyers.GetBuyersById(PFID);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Save Buyers
        /// </summary>
        /// <param name="buyersModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveBuyers(BuyersModel buyersModel)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = buyers.SaveBuyers(buyersModel);
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
