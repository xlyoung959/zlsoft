using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace case1.Controllers
{
    public class DeptController : Controller
    {
        DeptService deptService = new DeptService();
        Dept dept;

        // GET: Dept
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///  新增组织控制器
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public int insertDept()
        {
            dept.ID = Request.Form["id"];
            dept.上级ID = Request.Form["上级ID"];
            dept.位置 = Request.Form["位置"];
            dept.名称 = Request.Form["名称"];
            dept.建档时间 = Request.Form["建档时间"];
            dept.末级 = Request.Form["末级"];
            dept.环境类别 = Request.Form["环境类别"];
            dept.位置 = Request.Form["位置"];
            dept.站点 = Request.Form["站点"];
            dept.简码 = Request.Form["简码"];
            dept.编码 = Request.Form["编码"];
            return deptService.insertDept(dept);
        }
    }
}