using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ClientList.Entities.Custom_Validations;

namespace ClientList.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        public string Address { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        //Navigation Properties
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public Client()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
