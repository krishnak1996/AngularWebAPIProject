using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.Model;
using AngularWebAPIProject.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AngularWebAPIProject.BAL.Service
{
    public class AccountService : IAccount
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;
        public AccountService(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public LoginResponseModel Login(LoginModel loginModel)
        {
            LoginResponseModel loginResponseModel = new();
            if (!string.IsNullOrEmpty(loginModel.Email) && !string.IsNullOrEmpty(loginModel.Password))
            {
                var user = dbContext.ApplicationUser.Where(u => u.Email == loginModel.Email && u.Password == loginModel.Password).FirstOrDefault();
                if (user!=null)
                {
                    loginResponseModel.EmailAddress = loginModel.Email;
                    loginResponseModel.UserName = user.FirstName;
                    loginResponseModel.UserId = user.Id;
                    loginResponseModel.RoleId = user.RoleId;
                    loginResponseModel.Status = HttpStatusCode.OK.ToString();
                    loginResponseModel.Message = "Login Success !";
                }
                else
                {
                    loginResponseModel.Status = HttpStatusCode.OK.ToString();
                    loginResponseModel.Message = "Login Failed";
                    loginResponseModel.EmailAddress = loginModel.Email;
                }
            }
            else
            {
                loginResponseModel.Status = HttpStatusCode.OK.ToString();
                loginResponseModel.Message = "Please Enter Username and Password";
                loginResponseModel.EmailAddress = null;
            }
            return loginResponseModel;
        }

        /// <summary>
        /// Get Role
        /// </summary>
        /// <returns></returns>
        public List<RoleModel> GetRole()
        {
            List<RoleModel> roleModels = new();
            var roles = dbContext.RoleMaster.Where(u => u.IsActive == true).ToList();
            roleModels = mapper.Map<List<RoleModel>>(roles);
            return roleModels;
        }
    }
}
