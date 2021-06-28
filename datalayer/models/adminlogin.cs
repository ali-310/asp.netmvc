using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class adminlogin
    {
        [Key]
        public int loginid { get; set; }
         [Required(ErrorMessage = " لطفا{0}راوارد کنید")] [Display(Name =" نام کاربری")] [MaxLength(200)]
        public string username { get; set; }
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(250)]
        public string email { get; set; }
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(200)]
        public string password { get; set; }
    }
}
