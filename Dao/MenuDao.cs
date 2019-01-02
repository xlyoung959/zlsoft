using Domain;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class MenuDao
    {
        /// <summary>
        /// 根据用户名查询改用户的权限及用于哪些菜单
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable  selectMenuTree(string username)
        {
            string sql = @" select distinct a.ID,a.名称 as name,a.上级ID as parentId from 系统_菜单 a 
                 left join 系统_角色权限 b on a.id = b.菜单id left join 系统_角色成员 c on b.角色id = c.角色id 
                left join 系统_用户信息 d on c.用户id = d.id where d.用户名 =:username";
            OracleParameter[] prms = new OracleParameter[]
              {
                 new OracleParameter("username",OracleDbType.Varchar2,20) { Value=username}
              };
            var e= OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
            return e;
        }   

        /// <summary>
        /// 根据传来的ID查询该ID是否是为上级ID 有数据返回1 无返回0,判断是否有子节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int judgeIsParentId(String id)
        {
            string sql = "select ID from 系统_菜单 where 上级ID=:Id";
            OracleParameter[] prms = new OracleParameter[]
            {
                 new OracleParameter("Id",OracleDbType.Varchar2,32) { Value=id}
            };
            var e = OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
            if (e!=null && e.Rows.Count>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 根据ID查询菜单的内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable selectMenuById(String id)
        {
            string sql = "  select * from 系统_菜单 where ID=:Id";
            OracleParameter[] prms = new OracleParameter[]
             {
                 new OracleParameter("Id",OracleDbType.Varchar2,255) { Value=id}
             };
            var e = OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
            return e;
        }
    }
}
