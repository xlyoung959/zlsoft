﻿using System;
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
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteDept(int id)
        {

            string arr = "";
            DataTable dt = deptDao.selectDeptIdByPid(id);
            foreach (var r in dt.Rows)
            {
               arr+= r.ToString();
                arr += '|';
            }
                DataRow dr = dt.Rows[0];
                int? did = Convert.ToInt32(dr["ID"]);
                deptDao.deleteDept(id);
            while (did!=null)
            {
                deptDao.selectDeptIdByPid(Convert.ToInt32(did));
                 dr = dt.Rows[0];
                 did = Convert.ToInt32(dr["ID"]);
            }
            return deptDao.deleteDept(id);
        }

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
            
           
            var currentList = parentId==0? dt.Select("上级ID is NULL"): dt.Select("上级ID="+ parentId);
            if (currentList.Count() > 0)
            {
                foreach (var dr in currentList)
                {
                    var deptTree = new DeptTree();
                    deptTree.id = Convert.ToInt32(dr["ID"]);
                    deptTree.name = dr["名称"].ToString();
                    deptTree.pid = parentId;
                    deptTree.isParent = true;
                    treeList.Add(deptTree);
                    deptTree.children = getListByParentId(deptTree.id, dt);
                 
                }
            }
            return treeList;
        }



    }
}
