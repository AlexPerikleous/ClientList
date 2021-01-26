using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientList.Database;
using ClientList.Entities;
using System.Data.Entity;


namespace ClientList.Services
{
    public class ClientRepository
    {
        MyDatabase db = new MyDatabase();

        //GetAll()
        public IEnumerable<Client> GetAll()
        {
            return db.Clients.ToList();
        }

        //GetById
        public Client GetById(int? id)
        {
            return db.Clients.Find(id);
        }
        //Insert
        public void Insert(Client Client)
        {
            db.Entry(Client).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Client Client)
        {
            db.Entry(Client).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Client Client)
        {
            db.Entry(Client).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
