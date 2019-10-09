using Model.EntityF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class UserDAO
    {
        MyblogDbContext db = null;
        public UserDAO()
        {
            db = new MyblogDbContext();
        }
        public long Insert(tbl_UserName user)
        {
            user.CreatedDate = DateTime.Now;
            db.tbl_UserName.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public int Login(string userName, string passWord)
        {
            var result = db.tbl_UserName.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.IsAdmin == false)
                        return -1;
                    else
                    {
                        if (result.PassWord == passWord)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
            }
        }
        public tbl_UserName GetUserByUserName(string userName)
        {
            return db.tbl_UserName.SingleOrDefault(x => x.UserName == userName);
        }

        public IEnumerable<tbl_UserName> ListAllPaging(int page, int pageSize)
        {
            return db.tbl_UserName.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
    }
}
