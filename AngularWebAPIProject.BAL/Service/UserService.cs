using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Service
{
    public class UserService : IUser
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;
        public UserService(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetUserDetails()
        {
            ResponseModel responseModel = new();
            List<UserModel> userModels = new List<UserModel>();
            var applicationUsers = dbContext.ApplicationUser.Where(u => u.IsActive == true).ToList();
            if (applicationUsers.Any())
            {
                userModels.AddRange(applicationUsers.Select(m => new UserModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    MiddleName = m.MiddleName,
                    LastName = m.LastName,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Address = m.Address,
                    IsActive = m.IsActive
                }));
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = userModels;
            return responseModel;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public ResponseModel AddUser(UserModel userModel)
        {
            ResponseModel responseModel = new();
            if (userModel.Id > 0)
            {
                var applicationUser = dbContext.ApplicationUser.Where(u => u.Id == userModel.Id).FirstOrDefault();
                if (applicationUser != null)
                {
                    applicationUser.Id = userModel.Id;
                    applicationUser.FirstName = userModel.FirstName;
                    applicationUser.MiddleName = userModel.MiddleName;
                    applicationUser.LastName = userModel.LastName;
                    applicationUser.Email = userModel.Email;
                    applicationUser.PhoneNumber = userModel.PhoneNumber;
                    applicationUser.Address = userModel.Address;
                    applicationUser.Password = userModel.Password;
                    applicationUser.CreatedBy = userModel.CreatedBy;
                    applicationUser.CreatedOn = DateTime.Now;
                    this.dbContext.ApplicationUser.Update(applicationUser);
                    var result = this.dbContext.SaveChanges();
                    responseModel.Message = Message.Update;
                }
            }
            else
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    FirstName = userModel.FirstName,
                    MiddleName = userModel.MiddleName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    Address = userModel.Address,
                    Password = userModel.Password,
                    IsActive = userModel.IsActive,
                    CreatedBy = userModel.CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                this.dbContext.ApplicationUser.Add(applicationUser);
                var result = this.dbContext.SaveChanges();
                responseModel.Message = Message.Success;
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
           
            responseModel.Data = null;
            return responseModel;
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel GetUserById(int Id)
        {
            ResponseModel responseModel = new();
            UserModel userModel = new UserModel();
            var applicationUser = dbContext.ApplicationUser.Where(u => u.Id == Id).FirstOrDefault();
            if (applicationUser != null)
            {
                userModel.Id = applicationUser.Id;
                userModel.FirstName = applicationUser.FirstName;
                userModel.MiddleName = applicationUser.MiddleName;
                userModel.LastName = applicationUser.LastName;
                userModel.Email = applicationUser.Email;
                userModel.PhoneNumber = applicationUser.PhoneNumber;
                userModel.Address = applicationUser.Address;
                userModel.Password = applicationUser.Password;
                userModel.IsActive = applicationUser.IsActive;
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = userModel;
            return responseModel;
        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel DeleteUserById(int Id)
        {
            ResponseModel responseModel = new();
            UserModel userModel = new UserModel();
            var applicationUser = dbContext.ApplicationUser.Where(u => u.Id == Id).FirstOrDefault();
            if (applicationUser != null)
            {
                dbContext.ApplicationUser.Remove(applicationUser);
                var result = this.dbContext.SaveChanges();
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = null;
            return responseModel;
        }
    }
}
