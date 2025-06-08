using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.Model
{
    public class LoginResponseModel
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; } 
        public string? Token { get; set; } 
        public DateTime? ExpiryTime { get; set; } 
        public string? Status { get; set; } 
        public string? Message { get; set; } 
    }
}
