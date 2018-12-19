using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace case1.Controllers
{
    public class UserController : Controller
    {
        private UserService userService=new UserService();
        // GET: User用户管理控制器
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult LoginSubmit()
        {
            string name = Request.Form["username"];
            string password = Request.Form["password"];
            int L=userService.Login(name, password);
            if (L == 1)
            {
                ViewData["username"] = name;
                return View("Index");
            }
            else
            {
                ViewData["error"] = "密码或用户名错误";
                return View("Login");
            }

        }
    }
}