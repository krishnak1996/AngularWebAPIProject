using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL.Migrations;
using AngularWebAPIProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecordOpeningAPIController : ControllerBase
    {
        private readonly IRecordOpening recordOpening;
        public RecordOpeningAPIController(IRecordOpening recordOpening)
        { 
            this.recordOpening = recordOpening;
        }

        /// <summary>
        ///Get Record Opening By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRecordOpeningById(int Id)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = recordOpening.GetRecordOpeningById(Id);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Save Record Opening
        /// </summary>
        /// <param name="recordOpeningModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveRecordOpening(RecordOpeningModel recordOpeningModel)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = recordOpening.SaveRecordOpening(recordOpeningModel);
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
