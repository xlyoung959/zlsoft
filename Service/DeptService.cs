using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Domain;

namespace Service
{
   public  class DeptService
    {
        private DeptDao deptDao;

        /// <summary>
        /// 新增组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>int</returns>
        public int  insertDept(Dept dept)
        {
            return deptDao.insertDept(dept);
        }

    
    }
}
