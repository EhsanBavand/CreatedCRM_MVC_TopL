using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataSource
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "Page Group")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int GroupID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(250)]
        public string Title { get; set; }
                
        [Display(Name = "Summery")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }

        [Display(Name = "View")]
        public int Visit { get; set; }

        [Display(Name = "Image")]
        public string ImageName { get; set; }

        [Display(Name = "Slider")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "Create Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
        
        [Display(Name = "Words Key")]
        public string Tags { get; set; }

        public virtual List<PageComment> PageComments { get; set; }
        public virtual PageGroup PageGroup { get; set; }
        public Page()
        {

        }
    }
}
