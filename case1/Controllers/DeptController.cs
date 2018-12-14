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
        //返回组织结构页面
        public ActionResult Organization()
        {
            return View("Organization");
        }
        //去到添加组织结构页面
        public ActionResult AddDept()
        {
            return View("AddDept");
        }
        //去到科室的具体内容页面 DeptContent
        public ActionResult DeptContent(int id)
        {
            var data = deptService.selectDeptById(id);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化
            ViewData["Dept"] = dataStr;
            return View("DeptContent");
        }
       
        /// <summary>
        ///  新增组织控制器
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public int insertDept()
        {
            Dept dept = new Dept();
            dept.parentId =int.Parse( Request.Form["parentId"]);
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
        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public int updateDept()
        {
            //updateDept不用带参  改一下注意自己把ID从前台取到和DeptContent中的内容对应一下吧 只取parentId就行 parentname不要取哟
            //dao层李的末级删了吧，前台没有涉及到改，当然也可在前台加起  
            Dept dept = new Dept();
            return deptService.insertDept(dept);
        }


        /// <summary>
        /// 根据组织id获取组织的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContentResult getDeptById(int id)
        {
            var data = deptService.selectDeptById(id);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化          
            return Content(dataStr);
        }

        /// <summary>
        /// 根据id查询上级部门的名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns>上级组织的名称</returns>
        public ContentResult getPnameBypid(int id)
        {
            var pname =  deptService.queryPnameById(id);
            return Content(pname);
        }
        /// <summary>
        /// 删除组织(如果有子节点则不能删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteDept(int id)
        {
            return deptService.deleteDept(id);
        }
    }
}