using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class loginviewmodel
    {

     
        [Required(ErrorMessage = " لطفا{0} راوارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(200)]
        public string username { get; set; }

        [Required(ErrorMessage = " لطفا{0} راوارد کنید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool rememberme { get; set; }
    }
}
