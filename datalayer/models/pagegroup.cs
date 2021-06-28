using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class pagegroup
    {
        [Key]
        public int groupid { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = " لطفا{0}راوارد کنید")]
        [MaxLength(150)]
        public string grouptitle { get; set; }
        public virtual List<page> Pages { get; set; }
        public pagegroup()
        { 
        
        }
    }
}
