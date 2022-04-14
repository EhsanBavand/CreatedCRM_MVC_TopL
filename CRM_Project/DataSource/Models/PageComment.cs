using System;
using System.ComponentModel.DataAnnotations;

namespace DataSource
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }

        [Display(Name = "News")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int PageID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Display(Name = "Website")]
        [MaxLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Register Date")]
        public DateTime CreateDate { get; set; }

        public virtual Page Page { get; set; }
        public PageComment()
        {

        }
    }
}
