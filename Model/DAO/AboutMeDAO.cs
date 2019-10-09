using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class AboutMeDAO
    {
        MyblogDbContext db = null;
        public AboutMeDAO()
        {
            db = new MyblogDbContext();
        }
        public long InsertAboutMe(tbl_AboutMe about)
        {
            about.CreatedDate = DateTime.Now;
            about.MetaTitle = XuLyChuoi.GetMetaTitle(about.Title);
            db.tbl_AboutMe.Add(about);
            return about.ID;
        }
        public tbl_AboutMe GetAbout()
        {
            return db.tbl_AboutMe.SingleOrDefault(x => x.Status == true);
        }
        public tbl_AboutMe ViewDetail(long id)
        {
            return db.tbl_AboutMe.Find(id);
        }
        public bool Update(tbl_AboutMe aboutMe)
        {
            try
            {
                var about = db.tbl_AboutMe.Find(aboutMe.ID);
                about.FirstName = aboutMe.FirstName;
                about.LastName = aboutMe.LastName;
                about.Title = aboutMe.Title;
                about.MetaTitle = XuLyChuoi.GetMetaTitle(about.Title);
                about.Introduce = aboutMe.Introduce;
                about.Image = aboutMe.Image;
                about.MoreImage = aboutMe.MoreImage;
                about.ModifiedDate = DateTime.Now;
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
                var ab = db.tbl_AboutMe.Find(id);
                db.tbl_AboutMe.Remove(ab);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<tbl_AboutMe> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_AboutMe.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
