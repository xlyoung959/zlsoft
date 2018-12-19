using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Domain;
using System.Data;

namespace Service
{
    public class MenuService
    {
        MenuDao menuDao = new MenuDao();

        public string getMenuList()
        {
            return "gfe";
        }

        /// <summary>
        /// 先获取最高级的组织,然后调用getListByParentId方法,获取他的子节点
        /// </summary>
        /// <returns>返回MenuTree结构的list</returns>
        public List<MenuTree> getMenuTree(string username)
        {
            var resultList = new List<MenuTree>();

            DataTable dt = menuDao.selectMenuTree(username);
            resultList = getListByParentId("ROOT", dt);
            return resultList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId">上级Id</param>
        /// <param name="dt">查询出来的所有组织</param>
        /// <returns>返回树结构的组织机构</returns>
        public List<MenuTree> getListByParentId(string parentId, DataTable dt)
        {
            List<MenuTree> treeList = new List<MenuTree>();
            // parentId == "ROOT"? dt.Select("parentId='ROOT'") :
            var currentList = dt.Select("parentId='" + parentId+"'");
            if (currentList.Count() > 0)
            {
                foreach (var dr in currentList)
                {
                    var menuTree = new MenuTree();
                    menuTree.id = dr["ID"].ToString();
                    menuTree.name = dr["name"].ToString();
                    menuTree.pid =dr["parentId"].ToString();
                    if (menuTree.pid == "ROOT")
                    {
                        menuTree.isParent = true;
                    }
                    else
                    {//判断该节点还有无子节点，若无 isParent = false
                        int isP = menuDao.judgeIsParentId(menuTree.id);
                        if (isP == 1)
                        {
                            menuTree.isParent = true;
                        }
                        else
                        {
                            menuTree.isParent = false;
                        }
                    }          
                    treeList.Add(menuTree);
                    menuTree.children = getListByParentId(menuTree.id, dt);
                }
            }
            return treeList;
        }

        public DataTable selectMenuById(string id)
        {
            return menuDao.selectMenuById(id);
        }
    }
}
