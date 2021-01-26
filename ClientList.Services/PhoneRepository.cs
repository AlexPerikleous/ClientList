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
    public class PhoneRepository
    {
        MyDatabase db = new MyDatabase();

        //GetAll()
        public IEnumerable<PhoneNumber> GetAll()
        {
            return db.PhoneNumbers.ToList();
        }

        //GetById
        public PhoneNumber GetById(int? id)
        {
            return db.PhoneNumbers.Find(id);
        }

        //GetByClientId
        public IEnumerable<PhoneNumber> GetByClientId(int? clientId)
        {
            return db.PhoneNumbers.Where(phone=>phone.ClientId == clientId).ToList();
        }

        //GetByClientIdAndType
        public PhoneNumber GetByClientIdAndType(int? clientId, PhoneNumberType numberType)
        {
            return db.PhoneNumbers.FirstOrDefault(phone => phone.ClientId == clientId && phone.PhoneNumberType == numberType);
        }
        //Insert
        public void Insert(PhoneNumber PhoneNumber)
        {
            db.Entry(PhoneNumber).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(PhoneNumber PhoneNumber)
        {
            db.Entry(PhoneNumber).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(PhoneNumber PhoneNumber)
        {
            db.Entry(PhoneNumber).State = EntityState.Deleted;
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
