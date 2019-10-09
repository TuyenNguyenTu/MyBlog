using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class FeedBackDAO
    {
        MyblogDbContext db = null;
        public FeedBackDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_FeedBack feedBack)
        {
            feedBack.CreatedDate = DateTime.Now;
            feedBack.Status = true;
            feedBack.CreatedDate = DateTime.Now;
            db.tbl_FeedBack.Add(feedBack);
            db.SaveChanges();
            return feedBack.ID;
        }
        public tbl_FeedBack GetFeedBackActive()
        {
            return db.tbl_FeedBack.SingleOrDefault(x => x.Status == true);
        }
        public tbl_FeedBack ViewDetail(long id)
        {
            return db.tbl_FeedBack.Find(id);
        }
        public bool Update(tbl_FeedBack feedBack)
        {
            try
            {
                var feed = db.tbl_FeedBack.Find(feedBack.ID);
                feed.Name = feedBack.Name;
                feed.Phone = feedBack.Phone;
                feed.Status = feedBack.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var ab = db.tbl_FeedBack.Find(id);
                db.tbl_FeedBack.Remove(ab);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<tbl_FeedBack> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_FeedBack.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
