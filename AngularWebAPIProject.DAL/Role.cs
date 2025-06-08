using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.DAL
{
    public class RoleMaster
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
