using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyBlog.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page=1, int pageSize = 1)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}