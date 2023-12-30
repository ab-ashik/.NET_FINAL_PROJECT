using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DiscountCuponRepo : Repo, IRepo<DiscountCupon, int, DiscountCupon>
    {
        public DiscountCupon Create(DiscountCupon obj)
        {
            db.DiscountCupons.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.DiscountCupons.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<DiscountCupon> Read()
        {
            return db.DiscountCupons.ToList();
        }

        public DiscountCupon Read(int id)
        {
            return db.DiscountCupons.Find(id);

        }

        public DiscountCupon Update(DiscountCupon obj)
        {
            var ex = Read(obj.CuponID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
