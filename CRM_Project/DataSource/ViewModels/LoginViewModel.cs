using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
