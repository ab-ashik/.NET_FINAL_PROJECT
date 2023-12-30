using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ServiceRepo : Repo, IRepo<Service, int, Service>
    {
        public Service Create(Service obj)
        {
            db.Services.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Services.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Service> Read()
        {
            return db.Services.ToList();
        }

        public Service Read(int id)
        {
            return db.Services.Find(id);
        }

        public Service Update(Service obj)
        {
            var ex = Read(obj.ServiceID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
