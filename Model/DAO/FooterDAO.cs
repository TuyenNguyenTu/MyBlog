using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FooterDAO
    {
        MyblogDbContext db = null;
        public FooterDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_Footer footer)
        {
            footer.CreatedDate = DateTime.Now;
            footer.Status = true;
            return footer.ID;
        }
        public bool Update (tbl_Footer footer)
        {
            try
            {
                var foot = db.tbl_Footer.Find(footer.ID);
                foot.Contents = footer.Contents;
                foot.ModifiedDate = DateTime.Now;
                foot.Status = footer.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete( long id)
        {
            try
            {
                var entity = db.tbl_Footer.Find(id);
                db.tbl_Footer.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public IEnumerable<tbl_Footer> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_Footer.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public tbl_Footer GetFooterActive()
        {
            return db.tbl_Footer.SingleOrDefault(x => x.Status == true);
        }
        public tbl_Footer ViewDetail(long id)
        {
            return db.tbl_Footer.Find(id);
        }
    }
}
