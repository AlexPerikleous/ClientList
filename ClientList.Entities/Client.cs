using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientList.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required, MaxLength(60), MinLength(2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(60), MinLength(2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(60), MinLength(2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Address { get; set; }

        [Required, MaxLength(60), MinLength(2)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
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
