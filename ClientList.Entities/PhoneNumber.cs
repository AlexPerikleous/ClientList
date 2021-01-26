using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientList.Entities
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        
        
        public PhoneNumberType PhoneNumberType { get; set; }
        [Required, MaxLength(15), MinLength(8)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }



        //[Required, MaxLength(60), MinLength(2)]
        //[Display(Name = "First Name")]
        //public string HomeNumber { get; set; }
        //[Required, MaxLength(60), MinLength(2)]
        //[Display(Name = "First Name")]
        //public string OfficeNumber { get; set; }
        //[Required, MaxLength(60), MinLength(2)]
        //[Display(Name = "First Name")]
        //public string MobileNumber { get; set; }

    }
}
