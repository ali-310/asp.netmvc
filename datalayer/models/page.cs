using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace datalayer
{
   public class page
    {
        [Key]
        public int pageid { get; set; }
          [Display(Name ="گروه صفحه")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        public int groupid { get; set; }
        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [MaxLength(200)]
        public string title { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string shortdescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string text { get; set; }
        [Display(Name = "بازدید")]
        public int visit { get; set; }
        [Display(Name = "تصویر")]
        public string imgname { get; set; }
        [Display(Name = "اسلایدر")]
        public bool showinslider { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString ="{0: yyyy/mm/dd}")]
        public DateTime createdate { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string tag { get; set; }
        public virtual pagegroup pagegroup { get; set; }
        public virtual List<pagecomment> Pagecomments { get; set; }

        public page()
        {

        }

    }
}
