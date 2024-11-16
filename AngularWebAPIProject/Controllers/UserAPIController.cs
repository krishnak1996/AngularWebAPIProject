using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUser user;
        public UserAPIController(IUser user)
        {
            this.user = user;
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserDetails()
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = user.GetUserDetails();
                return Ok(responseModel);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = user.AddUser(userModel);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserById(int Id)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = user.GetUserById(Id);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteUserById(int Id)
        {
            try
            {
                ResponseModel responseModel = new();
                responseModel = user.DeleteUserById(Id);
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
