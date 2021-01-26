using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClientList.Entities;
namespace ClientList.Database
{
    public class MyDatabase : DbContext
    {
        public MyDatabase() : base("Connection")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
