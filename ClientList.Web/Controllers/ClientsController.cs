using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientList.Database;
using ClientList.Entities;
using ClientList.Services;
using ClientList.Web.Models;

namespace ClientList.Web.Controllers
{
    public class ClientsController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            //PhoneNumber p1 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Home };
            //PhoneNumber p2 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Mobile };
            //PhoneNumber p3 = new PhoneNumber() { PhoneNumberType = PhoneNumberType.Office };
            //ViewBag.PhoneNumbers = new List<PhoneNumber>() { p1, p2, p3 };
            //ClientPhoneViewModel clientPhoneViewModel = new ClientPhoneViewModel();
            //clientPhoneViewModel.HomeNumber = new PhoneNumber();
            //clientPhoneViewModel.HomeNumber.PhoneNumberType = PhoneNumberType.Home;
            //clientPhoneViewModel.MobileNumber = new PhoneNumber();
            //clientPhoneViewModel.MobileNumber.PhoneNumberType = PhoneNumberType.Mobile;
            //clientPhoneViewModel.OfficeNumber = new PhoneNumber();
            //clientPhoneViewModel.OfficeNumber.PhoneNumberType = PhoneNumberType.Office;
            return View(new ClientPhoneViewModel());
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ClientId,FirstName,LastName,Address,Email")] Client client)
        public ActionResult Create(ClientPhoneViewModel clientPhoneViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new Client();
                client.FirstName = clientPhoneViewModel.FirstName;
                client.LastName = clientPhoneViewModel.LastName;
                client.Address = clientPhoneViewModel.Address;
                client.Email = clientPhoneViewModel.Email;
                if (clientPhoneViewModel.HomeNumber != null)
                {
                    clientPhoneViewModel.HomeNumber.PhoneNumberType = PhoneNumberType.Home;
                    client.PhoneNumbers.Add(clientPhoneViewModel.HomeNumber);
                }
                if (clientPhoneViewModel.MobileNumber != null)
                {
                    clientPhoneViewModel.MobileNumber.PhoneNumberType = PhoneNumberType.Mobile;
                    client.PhoneNumbers.Add(clientPhoneViewModel.MobileNumber);
                }
                if (clientPhoneViewModel.OfficeNumber != null)
                {
                    clientPhoneViewModel.OfficeNumber.PhoneNumberType = PhoneNumberType.Office;
                    client.PhoneNumbers.Add(clientPhoneViewModel.OfficeNumber);
                }

                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientPhoneViewModel);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            PhoneRepository phoneRepository = new PhoneRepository();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ClientPhoneViewModel clientPhoneViewModel = new ClientPhoneViewModel();
            clientPhoneViewModel.ClientId = id;
            clientPhoneViewModel.FirstName = client.FirstName;
            clientPhoneViewModel.LastName = client.LastName;
            clientPhoneViewModel.Address = client.Address;
            clientPhoneViewModel.Email = client.Email;
            clientPhoneViewModel.HomeNumber = phoneRepository.GetByClientIdAndType(id, PhoneNumberType.Home);
            clientPhoneViewModel.MobileNumber = phoneRepository.GetByClientIdAndType(id, PhoneNumberType.Mobile);
            clientPhoneViewModel.OfficeNumber = phoneRepository.GetByClientIdAndType(id, PhoneNumberType.Office);
            return View(clientPhoneViewModel);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientPhoneViewModel clientPhoneViewModel)
        {
            if (ModelState.IsValid)
            {
                //var client = new Client();
                //client.FirstName = clientPhoneViewModel.FirstName;
                //client.LastName = clientPhoneViewModel.LastName;
                //client.Address = clientPhoneViewModel.Address;
                //client.Email = clientPhoneViewModel.Email;
                //if (clientPhoneViewModel.HomeNumber != null)
                //{
                //    client.PhoneNumbers.Add(clientPhoneViewModel.HomeNumber);
                //}
                //if (clientPhoneViewModel.MobileNumber != null)
                //{
                //    client.PhoneNumbers.Add(clientPhoneViewModel.MobileNumber);
                //}
                //if (clientPhoneViewModel.OfficeNumber != null)
                //{
                //    client.PhoneNumbers.Add(clientPhoneViewModel.OfficeNumber);
                //}
                //var client =
                //from clients in db.Clients
                //where clients.ClientId == clientPhoneViewModel.ClientId
                //select clients;
                PhoneRepository phoneRepository = new PhoneRepository();
                Client client = db.Clients.Find(clientPhoneViewModel.ClientId);
                client.FirstName = clientPhoneViewModel.FirstName;
                client.LastName = clientPhoneViewModel.LastName;
                client.Address = clientPhoneViewModel.Address;
                client.Email = clientPhoneViewModel.Email;

                PhoneNumber homeNumber = client.PhoneNumbers.FirstOrDefault(phone => phone.PhoneNumberType == PhoneNumberType.Home);
                PhoneNumber mobileNumber = client.PhoneNumbers.FirstOrDefault(phone => phone.PhoneNumberType == PhoneNumberType.Mobile);
                PhoneNumber officeNumber = client.PhoneNumbers.FirstOrDefault(phone => phone.PhoneNumberType == PhoneNumberType.Office);

                if (homeNumber != null)
                {
                    homeNumber.Phone = clientPhoneViewModel.HomeNumber.Phone;
                }
                else
                {
                    clientPhoneViewModel.HomeNumber.PhoneNumberType = PhoneNumberType.Home;
                    client.PhoneNumbers.Add(clientPhoneViewModel.HomeNumber);
                }

                if (mobileNumber != null)
                {
                    mobileNumber.Phone = clientPhoneViewModel.MobileNumber.Phone;
                }
                else
                {
                    clientPhoneViewModel.MobileNumber.PhoneNumberType = PhoneNumberType.Mobile;
                    client.PhoneNumbers.Add(clientPhoneViewModel.MobileNumber);
                }

                if (officeNumber != null)
                {
                    officeNumber.Phone = clientPhoneViewModel.OfficeNumber.Phone;
                }
                else
                {
                    clientPhoneViewModel.OfficeNumber.PhoneNumberType = PhoneNumberType.Office;
                    client.PhoneNumbers.Add(clientPhoneViewModel.OfficeNumber);
                }


                //if (!client.PhoneNumbers.Contains(clientPhoneViewModel.HomeNumber))
                //{
                //    clientPhoneViewModel.HomeNumber.PhoneNumberType = PhoneNumberType.Home;
                //    client.PhoneNumbers.Add(clientPhoneViewModel.HomeNumber);
                //}
                //if (!client.PhoneNumbers.Contains(clientPhoneViewModel.MobileNumber))
                //{
                //    clientPhoneViewModel.MobileNumber.PhoneNumberType = PhoneNumberType.Mobile;
                //    client.PhoneNumbers.Add(clientPhoneViewModel.MobileNumber);
                //}
                //if (!client.PhoneNumbers.Contains(clientPhoneViewModel.OfficeNumber))
                //{
                //    clientPhoneViewModel.OfficeNumber.PhoneNumberType = PhoneNumberType.Office;
                //    client.PhoneNumbers.Add(clientPhoneViewModel.OfficeNumber);
                //}

                //PhoneNumber homeNumber = phoneRepository.GetByClientIdAndType(clientPhoneViewModel.ClientId, PhoneNumberType.Home);
                //PhoneNumber mobileNumber = phoneRepository.GetByClientIdAndType(clientPhoneViewModel.ClientId, PhoneNumberType.Mobile);
                //PhoneNumber officeNumber = phoneRepository.GetByClientIdAndType(clientPhoneViewModel.ClientId, PhoneNumberType.Office);
                //if (homeNumber != null)
                //{
                //    homeNumber.Phone = clientPhoneViewModel.HomeNumber.Phone;
                //}
                //homeNumber.Phone = client
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientPhoneViewModel);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
