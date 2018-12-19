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

        /// <summary>
        /// 点击登录 判断用户名和密码
        /// </summary>
        /// <returns></returns>
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

        //退出登录
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }
    }
}