using Model.DAO;
using MyBlog.Areas.Admin.Models;
using MyBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, model.PassWord);
                if (result == 1)
                {
                    var user = dao.GetUserByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản ");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không được cấp phép hoặc đang bị khóa");
                }
                else
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
            }


            return View("Index");
        }
    }
}