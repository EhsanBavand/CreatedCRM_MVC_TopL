using System.ComponentModel.DataAnnotations;


namespace DataSource.Models
{
    public class AdminLogin
    {
        [Key]
        public int LoginID { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(200)]

        public string Password { get; set; }

    }
}
