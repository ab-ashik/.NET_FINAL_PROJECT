using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, IRepo<Notification, int, Notification>
    {
        public Notification Create(Notification obj)
        {
            db.Notifications.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Notifications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Notification> Read()
        {
            return db.Notifications.ToList();
        }

        public Notification Read(int id)
        {
            return db.Notifications.Find(id);
        }

        public Notification Update(Notification obj)
        {
            var ex = Read(obj.NotificationID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
