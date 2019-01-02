using Domain;
using Service;
using System;
using System.Web.Mvc;

namespace case1.Controllers
{
    public class DeptController : Controller
    {
        DeptService deptService = new DeptService(); 

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
        public ActionResult EditDept(int id)
        {
            var data = deptService.selectDeptById(id);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化
            ViewData["Dept"] = dataStr;
            return View("EditDept");
        }
       
        /// <summary>
        ///  新增组织控制器
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult insertDept()
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
            int i= deptService.insertDept(dept);
            if (i > 0)
            {
                ViewData["erro"] = "添加成功";
             
                return View("Organization");
            }
            else
            {
                ViewData["erro"] = "添加失败";
                return View("AddDept");
            }
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
        public ActionResult updateDept()
        {
            Dept dept = new Dept();
            dept.Id = Int32.Parse(Request.Form["id"]);
            dept.code = Request.Form["code"];
            dept.parentId = Int32.Parse(Request.Form["parentId"]);
            dept.location = Request.Form["location"];
            dept.name = Request.Form["name"];
            dept.simCode = Request.Form["simCode"];
            dept.envCat = Request.Form["envCat"];
            dept.location = Request.Form["location"];
            dept.site = Request.Form["site"];
            dept.createTime = Request.Form["createTime"];

            int u= deptService.updateDept(dept);
            if (u > 0)
            {
                var data = deptService.selectDeptById(dept.Id);
                var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化
                ViewData["Dept"] = dataStr;
                ViewData["erro"] = "修改成功";
                return View("DeptContent");
            }
            else
            {
                var data = deptService.selectDeptById(dept.Id);
                var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化
                ViewData["Dept"] = dataStr;
                ViewData["erro"] = "修改失败";
                return View("DeptContent");
            }
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