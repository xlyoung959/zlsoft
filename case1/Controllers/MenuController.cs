using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace case1.Controllers
{
    public class MenuController : Controller
    {
        private MenuService menuService=new MenuService();
        // GET: Menu
        public ActionResult MenuManagement()
        {
            return View("MenuManagement");
        }
        //得到菜单的树形结构数据
        public JsonResult getMenuTree(string username)
        {
            var data=menuService.getMenuTree(username);
            return Json(data);
        }

        //跳转到菜单的内容页面，并且把菜单的内容传过去
        public ActionResult MenuContent(string id)
        {
            var data = menuService.selectMenuById(id);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);//序列化
            ViewData["Menu"] = dataStr;
            return View("MenuContent");
        }
        public int deleteMenu(int id)
        {
            return 1;
        }
    }
}