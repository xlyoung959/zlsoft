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
    public class DeptService
    {
        private DeptDao deptDao = new DeptDao();



        /// <summary>
        /// 新增组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>所影响的行数</returns>
        public int insertDept(Dept dept)
        {
            return deptDao.insertDept(dept);
        }



        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="dept">部门实体类</param>
        /// <returns>所影响的行数</returns>
        public int updateDept(Dept dept)
        {
            return deptDao.updateDept(dept);
        }



        /// <summary>
        /// 删除(如果有子节点就不能删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteDept(int id)
        {
            DataTable dt = deptDao.selectDeptIdByPid(id);
            if (dt.Rows.Count == 0)
            {
               return deptDao.deleteDept(id);
            }
            else
            {
                return -1;
            }
        }

        ///// <summary>
        ///// 删除组织
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public int deleteDept(int id)
        //{

        //    string arr = "";
        //    DataTable dt = deptDao.selectDeptIdByPid(id);
        //    foreach (var r in dt.Rows)
        //    {
        //       arr+= r.ToString();
        //        arr += '|';
        //    }
        //        DataRow dr = dt.Rows[0];
        //        int? did = Convert.ToInt32(dr["ID"]);
        //        deptDao.deleteDept(id);
        //    while (did!=null)
        //    {
        //        deptDao.selectDeptIdByPid(Convert.ToInt32(did));
        //         dr = dt.Rows[0];
        //         did = Convert.ToInt32(dr["ID"]);
        //    }
        //    return deptDao.deleteDept(id);
        //}

        /// <summary>
        /// 先获取最高级的组织,然后调用getListByParentId方法,获取他的子节点
        /// </summary>
        /// <returns>返回DeptTree结构的list</returns>
        public List<DeptTree> getTree()
        {
            var resultList = new List<DeptTree>();

            DataTable dt = deptDao.selectDeptTree();
            resultList = getListByParentId(0, dt);
            return resultList;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId">上级Id</param>
        /// <param name="dt">查询出来的所有组织</param>
        /// <returns>返回树结构的组织机构</returns>
        public List<DeptTree> getListByParentId(int parentId, DataTable dt)
        {
            List<DeptTree> treeList = new List<DeptTree>();
            
           
            var currentList = parentId==0? dt.Select("parentId is NULL") : dt.Select("parentId=" + parentId);
            if (currentList.Count() > 0)
            {
                foreach (var dr in currentList)
                {
                    var deptTree = new DeptTree();
                    deptTree.id = Convert.ToInt32(dr["ID"]);
                    deptTree.name = dr["name"].ToString();
                    deptTree.pid = parentId;
                    deptTree.isParent = true;
                    treeList.Add(deptTree);
                    deptTree.children = getListByParentId(deptTree.id, dt);
                 
                }
            }
            return treeList;
        }



        /// <summary>
        /// 修改页，上级部门的值
        /// </summary>
        /// <param name="id"></param>
        /// <returns>上级部门的名称</returns>
        public string queryPnameById(int id)
        {
            //根据组织id查询他的上级id
            DataTable dt =deptDao.selectDeptById(id);
            DataRow dr =  dt.Rows[0];
            int? pid = Convert.ToInt32( dr["parentId"]);
            if (pid == null)
            {
                return "";
            }
            else
            {
                //根据查到的上级id调用selectDeptById方法，查寻上级组织的名称
                DataRow dr1 = deptDao.selectDeptById((int)pid).Rows[0];
                string pname = dr1["name"].ToString();
                return pname;
            }
        }

        /// <summary>
        /// 根据id查询该部门的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable selectDeptById(int id)
        {
           
            return deptDao.selectDeptById(id);
        }

    }
}
