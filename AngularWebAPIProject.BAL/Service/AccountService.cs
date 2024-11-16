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

namespace AngularWebAPIProject.BAL.Service
{
    public class AccountService : IAccount
    {
        private readonly DatabaseContext dbContext;
        public AccountService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ResponseModel Login(LoginModel loginModel)
        {
            ResponseModel responseModel = new();
            if (!string.IsNullOrEmpty(loginModel.Email) && !string.IsNullOrEmpty(loginModel.Password))
            {
                var IsUserExist = dbContext.ApplicationUser.Where(u => u.Email == loginModel.Email && u.Password == loginModel.Password).Any();
                if (IsUserExist)
                {
                    responseModel.Id = 1;
                    responseModel.Status = HttpStatusCode.OK.ToString();
                    responseModel.Message = "Login Success";
                    responseModel.Data = null;
                }
                else
                {
                    responseModel.Id = -1;
                    responseModel.Status = HttpStatusCode.OK.ToString();
                    responseModel.Message = "Login Failed";
                    responseModel.Data = null;
                }
            }
            else
            {
                responseModel.Id = 0;
                responseModel.Status = HttpStatusCode.OK.ToString();
                responseModel.Message = "Please Enter Username and Password";
                responseModel.Data = null;
            }
            return responseModel;
        }

    }
}
