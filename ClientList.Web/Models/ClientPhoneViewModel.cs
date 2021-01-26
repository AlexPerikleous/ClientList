using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientList.Entities;
using ClientList.Services;

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
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }

            public PhoneNumber HomeNumber { get; set; }
            public PhoneNumber MobileNumber { get; set; }
            public PhoneNumber OfficeNumber { get; set; }
        //}
    }
}