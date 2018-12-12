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
            
            return View("Index");
        }
        public ActionResult Content()
        {

            return View("deptContent");
        }
        /// <summary>
        ///  新增组织控制器
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public int insertDept()
        {
            dept.Id = int.Parse(Request.Form["Id"]);
            dept.parentId = int.Parse(Request.Form["parentId"]);
            dept.location = Request.Form["location"];
            dept.name = Request.Form["name"];
            dept.createTime = Request.Form["createTime"];
            dept.finalNode = int.Parse(Request.Form["finalNode"]);
            dept.envCat = Request.Form["envCat"];
            dept.location = Request.Form["location"];
            dept.site = Request.Form["site"];
            dept.simCode = Request.Form["simCode"];
            dept.code = Request.Form["code"];
            return deptService.insertDept(dept);
        }
        /// <summary>
        /// 返回组织列表树结构
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getDeptTree()
        {
            var data = deptService.getTree();
            return Json(data);
        }
    }
}