using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class pagecomment
    {
        [Key]
        public int commentid { get; set; }
        [Display(Name ="خبر")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")] 
        public int pageid { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [MaxLength(150)]
        public string name { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        public string email { get; set; }
        [Display(Name = "وب سایت")]
        [MaxLength(200)]
        public string website { get; set; }
        [Display(Name = "نظر")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")] 
        [MaxLength(500)]
        public string comment { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime createdate { get; set; }
        public virtual  page Page { get; set; }
        public pagecomment()
        {

        }

    }
}
