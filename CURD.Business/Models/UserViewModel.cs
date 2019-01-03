using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.Business.Models
{
    public class UserViewModel
    {
        
        public long userid { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Please enter valid email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        [DataType(DataType.PhoneNumber)]
        public string mobile { get; set; }
        public bool? isactivated { get; set; }
    }
}
