using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.Data;
using Domain;

namespace case1.Controllers
{
    public class UserController : Controller
    {
        private UserService userService=new UserService();
        // GET: User用户管理控制器,跳转到登录页面
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

        /// <summary>
        /// 进入给用户分配角色的页面，就是点击角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult AssignRole()
        {
            return View("AssignRole");
        }

        /// <summary>
        /// 根据角色ID得到哪些用户没有该角色
        /// </summary>
        /// <returns></returns>
        public ContentResult GetUserNotRole(string roleId)
        {
            var data = userService.GetUserNotRole(roleId);
          var dataStr=Newtonsoft.Json.JsonConvert.SerializeObject(data);
            
            return Content(dataStr);   
        }

        /// <summary>
        /// 根据角色ID得到哪些用户已经有了该角色
        /// </summary>
        /// <returns></returns>
        public ContentResult GetUserHaveRole(string roleId)
        {
            var data = userService.GetUserHaveRole(roleId);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

        /// <summary>
        /// 得到说有角色的名称
        /// </summary>
        /// <returns></returns>
        public ContentResult GetAllRoleName()
        {
            var data = userService.GetAllRoleName();
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

        //给用户分配角色
        public int AddRoleOfUser(string[] username,string roleId)
        {
            var sum = 0;
            for(int i = 0; i < username.Length; i++)
            {
               int a= userService.AddRoleOfUser(username[i], roleId);
                if (a > 0)
                {
                    sum++;
                }
            }
            //判断总的受影响的行数，如果等于传来的用户名数组的长度，就是全部分配角色完成，则返回sum,若没有返回0
            if(sum == username.Length)
            {
                return sum;
            }
            else
            {
                return 0;
            }
        }

        //移除用的该角色
        public int MoveRoleOfUser(string[] username, string roleId)
        {
            var sum = 0;
            for (int i = 0; i < username.Length; i++)
            {
                int a = userService.MoveRoleOfUser(username[i], roleId);
                if (a > 0)
                {
                    sum++;
                }
            }
            //判断总的受影响的行数，如果等于传来的用户名数组的长度，就是全部分配角色完成，则返回sum,若没有返回0
            if (sum == username.Length)
            {
                return sum;
            }
            else
            {
                return 0;
            }
        }


    }
}