﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập tài khoản")]
        public string UserName { set; get; }
        [Required(ErrorMessage ="Nhập mật khẩu")]
        public string PassWord { set; get; }
        public bool Remember { set; get; }
    }
}