using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ImagePostsDAO
    {
        MyblogDbContext db = null;
        public ImagePostsDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_ImagePosts imagePosts)
        {
            imagePosts.Status = true;
            db.tbl_ImagePosts.Add(imagePosts);
            db.SaveChanges();
            return imagePosts.ID;
        }
        public bool Update(tbl_ImagePosts imagePosts)
        {
            try
            {
                var entity = db.tbl_ImagePosts.Find(imagePosts.ID);
                entity.Images = imagePosts.Images;
                entity.Status = imagePosts.Status;
                entity.tbl_Posts.ID = imagePosts.tbl_Posts.ID;
                entity.AltForImage = imagePosts.AltForImage;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var entity = db.tbl_ImagePosts.Find(id);
                db.tbl_ImagePosts.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public tbl_ImagePosts GetImagePostsActive()
        {
            return db.tbl_ImagePosts.SingleOrDefault(x => x.Status == true);
        }
        public tbl_ImagePosts ViewDetail(long id)
        {
            return db.tbl_ImagePosts.Find(id);
        }
        public IEnumerable<tbl_ImagePosts> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_ImagePosts.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
