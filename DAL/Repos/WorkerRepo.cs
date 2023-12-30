using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WorkerRepo : Repo, IRepo<Worker, int, Worker>
    {
        public Worker Create(Worker obj)
        {
            db.Workers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Workers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Worker> Read()
        {
            return db.Workers.ToList();
        }

        public Worker Read(int id)
        {
            return db.Workers.Find(id);
        }

        public Worker Update(Worker obj)
        {
            var ex = Read(obj.WorkerID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}