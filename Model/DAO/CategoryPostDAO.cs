using Model.EntityF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryPostDAO
    {
        MyblogDbContext db = null;
        public CategoryPostDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_CategoriesPosts categoriesPosts)
        {
            categoriesPosts.CratedDate = DateTime.Now;
            categoriesPosts.MetaTitle = XuLyChuoi.GetMetaTitle(categoriesPosts.CategoryName);
            db.tbl_CategoriesPosts.Add(categoriesPosts);
            db.SaveChanges();
            return categoriesPosts.ID;
        }
        public tbl_CategoriesPosts GetPostsActive()
        {
            return db.tbl_CategoriesPosts.SingleOrDefault(x => x.Status == true);
        }
        public tbl_CategoriesPosts ViewDetail(long id)
        {
            return db.tbl_CategoriesPosts.Find(id);
        }
        public bool Update(tbl_CategoriesPosts category)
        {
            try
            {
                var cate = db.tbl_CategoriesPosts.Find(category.ID);
                cate.CategoryName = category.CategoryName;
                cate.MetaTitle = XuLyChuoi.GetMetaTitle(cate.CategoryName);
                cate.ModifiedDate = DateTime.Now;
                cate.Status = category.Status;
                cate.ModifiedBy = category.ModifiedBy;
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
                var ab = db.tbl_CategoriesPosts.Find(id);
                db.tbl_CategoriesPosts.Remove(ab);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<tbl_CategoriesPosts> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_CategoriesPosts.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
