using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
  public class MenuDAO
    {
        MyblogDbContext db = null;
        public MenuDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_Menu menu)
        {
            db.tbl_Menu.Add(menu);
            db.SaveChanges();
            return menu.ID;
        }
        public bool Update(tbl_Menu menu)
        {
            try
            {
                var entity = db.tbl_Menu.Find(menu.ID);
                entity.Text = menu.Text;
                entity.Status = menu.Status;
                entity.Text = menu.Text;
                entity.tbl_TypeMenu.ID = menu.tbl_TypeMenu.ID;
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
                var entity = db.tbl_Menu.Find(id);
                db.tbl_Menu.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public tbl_Menu GetImageMenuActive()
        {
            return db.tbl_Menu.SingleOrDefault(x => x.Status == true);
        }
        public tbl_Menu ViewDetail(long id)
        {
            return db.tbl_Menu.Find(id);
        }
        public IEnumerable<tbl_Menu> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_Menu.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
