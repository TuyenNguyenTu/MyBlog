using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideDAO
    {
        MyblogDbContext db = null;
        public SlideDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_Slide slide)
        {
            slide.CreatedDate = DateTime.Now;
            db.tbl_Slide.Add(slide);
            db.SaveChanges();
            return slide.ID;
        }
        public bool Update(tbl_Slide slide)
        {
            try
            {
                var entity = db.tbl_Slide.Find(slide.ID);
                entity.Decription = slide.Decription;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = slide.Status;
                entity.Image = slide.Image;
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
                var entity = db.tbl_Slide.Find(id);
                db.tbl_Slide.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public tbl_Slide GetImageSlidesActive()
        {
            return db.tbl_Slide.SingleOrDefault(x => x.Status == true);
        }
        public tbl_Slide ViewDetail(long id)
        {
            return db.tbl_Slide.Find(id);
        }
        public IEnumerable<tbl_Slide> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_Slide.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
