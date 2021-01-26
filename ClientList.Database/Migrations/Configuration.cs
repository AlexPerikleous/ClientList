namespace ClientList.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClientList.Database;
    using ClientList.Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientList.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabase context)
        {

            //=================Seeding Clients=================
            Client c1 = new Client() { FirstName = "John", LastName = "Crane", Email = "JohnCrane@gmail.com", Address = "Boulevard Avenue 225"};
            Client c2 = new Client() { FirstName = "Kate", LastName = "Oliver", Email = "KateOliver@gmail.com", Address = "Poseidon Avenue 125" };
            Client c3 = new Client() { FirstName = "Bill", LastName = "Drexler", Email = "BillDrexler@gmail.com", Address = "Pine Street 51" };
            Client c4 = new Client() { FirstName = "Brad", LastName = "James", Email = "BradJames@gmail.com", Address = "Old Town Road 23" };
            Client c5 = new Client() { FirstName = "Margot", LastName = "Johnson", Email = "MargotJohnson@gmail.com", Address = "Old Mill Road 13" };
            Client c6 = new Client() { FirstName = "Joseph", LastName = "Anthony", Email = "JosephAnthony@gmail.com", Address = "Elm Street 15" };
            Client c7 = new Client() { FirstName = "Ellen", LastName = "Howard", Email = "EllenHoward@gmail.com", Address = "New York Avenue 215" };
            Client c8 = new Client() { FirstName = "Sam", LastName = "Bowie", Email = "SamBowie@gmail.com", Address = "Palm Road 98" };
            Client c9 = new Client() { FirstName = "Zoe", LastName = "Foster", Email = "ZoeFoster@gmail.com", Address = "Roger Street 24" };
            Client c10 = new Client() { FirstName = "Jack", LastName = "Mayes", Email = "JackMayes@gmail.com", Address = "California Avenue 495" };
            //Client c = new Client() { FirstName = "", LastName = "", Email = "@gmail.com", DateOfBirth = new DateTime(1, 1, 1), DateOfDeath = null, PhotoUrl = "#", Salary = 0, Telephone = "000-00-00-000" };

            //=================Seeding Phones=================
            PhoneNumber p1 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2101111111"};
            PhoneNumber p2 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6931111111" };
            PhoneNumber p3 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2111111111" };

            PhoneNumber p4 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2102222222" };
            PhoneNumber p5 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6932222222" };
            PhoneNumber p6 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2112222222" };

            PhoneNumber p7 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2103333333" };
            PhoneNumber p8 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6933333333" };
            PhoneNumber p9 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2113333333" };

            PhoneNumber p10 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2104444444" };
            PhoneNumber p11 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6934444444" };
            PhoneNumber p12 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2114444444" };

            PhoneNumber p13 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2105555555" };
            PhoneNumber p14 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6935555555" };
            PhoneNumber p15 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2115555555" };

            PhoneNumber p16 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2106666666" };
            PhoneNumber p17 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6936666666" };
            PhoneNumber p18 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2116666666" };

            PhoneNumber p19 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2107777777" };
            PhoneNumber p20 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6937777777" };
            PhoneNumber p21 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2117777777" };

            PhoneNumber p22 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2108888888" };
            PhoneNumber p23 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6938888888" };
            PhoneNumber p24 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2118888888" };

            PhoneNumber p25 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home, Phone = "2109999999" };
            PhoneNumber p26 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile, Phone = "6939999999" };
            PhoneNumber p27 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2119999999" };
            //PhoneNumber p = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office, Phone = "2119999999" };

            //==========Add Phones to Clients
            c1.PhoneNumbers = new List<PhoneNumber>() { p1, p2, p3 };
            c2.PhoneNumbers = new List<PhoneNumber>() { p4, p5, p6 };
            c3.PhoneNumbers = new List<PhoneNumber>() { p7, p8, p9 };
            c4.PhoneNumbers = new List<PhoneNumber>() { p10, p11, p12 };
            c5.PhoneNumbers = new List<PhoneNumber>() { p13, p14, p15 };
            c6.PhoneNumbers = new List<PhoneNumber>() { p16, p17, p18 };
            c7.PhoneNumbers = new List<PhoneNumber>() { p19, p20, p21 };
            c8.PhoneNumbers = new List<PhoneNumber>() { p22, p23, p24 };
            c9.PhoneNumbers = new List<PhoneNumber>() { p25, p26, p27 };

            //==========Upsert Tables (Client,Phone--Automaticly creation of Movies)
            context.Clients.AddOrUpdate(x => x.FirstName, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);
            //conte
            context.SaveChanges();
        }
    }
}
