using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TypeMenuDAO
    {
        MyblogDbContext db = null;
        public TypeMenuDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_TypeMenu typeMenu)
        {
            db.tbl_TypeMenu.Add(typeMenu);
            return typeMenu.ID;
        }
        public bool Update(tbl_TypeMenu typeMenu)
        {
            try
            {
                var entity = db.tbl_TypeMenu.Find(typeMenu.ID);
                entity.Name = typeMenu.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var entity = db.tbl_TypeMenu.Find(id);
                db.tbl_TypeMenu.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public tbl_TypeMenu ViewDetail(long id)
        {
            return db.tbl_TypeMenu.Find(id);
        }
        public IEnumerable<tbl_TypeMenu> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_TypeMenu.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
