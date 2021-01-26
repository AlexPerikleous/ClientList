using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientList.Entities;
using ClientList.Services;
using System.ComponentModel.DataAnnotations;

namespace ClientList.Web.Models
{
    public class ClientPhoneViewModel
    {
        //public Client Client { get; set; }
        //public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        //public ClientPhoneViewModel(int? id)
        //{
        //    ClientRepository clientRepository = new ClientRepository();
        //    PhoneRepository phoneRepository = new PhoneRepository();

        //    Client = (id != null) ? clientRepository.GetById(id) : null;
        //    PhoneNumbers = (id != null) ? phoneRepository.GetByClientId(id) : null;
            public int? ClientId { get; set; }

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

            [Display(Name = "Home Phone")]
            public PhoneNumber HomeNumber { get; set; }

            [Display(Name = "Mobile Phone")]
            public PhoneNumber MobileNumber { get; set; }

            [Display(Name = "Office Phone")]
            public PhoneNumber OfficeNumber { get; set; }
        //}
    }
}