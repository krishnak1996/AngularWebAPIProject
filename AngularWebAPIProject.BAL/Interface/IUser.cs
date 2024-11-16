using AngularWebAPIProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Interface
{
    public interface IUser
    {
        ResponseModel GetUserDetails();
        ResponseModel AddUser(UserModel userModel);
        ResponseModel GetUserById(int Id);
        ResponseModel DeleteUserById(int Id);
    }
}
