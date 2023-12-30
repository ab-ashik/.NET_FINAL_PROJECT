using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ServiceHistoryRepo : Repo, IRepo<ServiceHistory, int, ServiceHistory>
    {
        public ServiceHistory Create(ServiceHistory obj)
        {
            db.ServicesHistories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.ServicesHistories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ServiceHistory> Read()
        {
            return db.ServicesHistories.ToList();
        }

        public ServiceHistory Read(int id)
        {
            return db.ServicesHistories.Find(id);
        }

        public ServiceHistory Update(ServiceHistory obj)
        {
            var ex = Read(obj.HistoryID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
