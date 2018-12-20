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
    public class UserDao
    {
        /// <summary>
        /// 登录，根据传来的用户名和密码查询数据是否有这条数据
        /// </summary>
        /// <param name="username">username用户名</param>
        /// <param name="password">password密码</param>
        /// <returns>正确，返回1 不正确返回0</returns>
        public int Login(string username,string password)
        {
            string sql = "select * from 系统_用户信息 where 用户名=:username and 密码=:password and 是否作废=0";
           OracleParameter[] prms = new OracleParameter[]
              {
                 new OracleParameter("username",OracleDbType.Varchar2,36) { Value=username},
                 new OracleParameter("password",OracleDbType.Varchar2,20) { Value=password}
              };
             var u=OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
            if (u != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// 根据传来的角色ID查询出哪些用户没有被赋予该角色
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserNotRole(string roleId)
        {
            string sql = "select 用户名 as username from 系统_用户信息 where ID not in (select 用户ID from 系统_角色成员 where 角色ID=:roleID)";
            OracleParameter[] prms = new OracleParameter[]
            { 
                 new OracleParameter("roleID",OracleDbType.Varchar2,36) { Value=roleId}
            };
            return  OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
        }

        /// <summary>
        /// 根据传来的角色ID查询出哪些用户被赋予该角色
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserHaveRole(string roleId)
        {
            string sql = "select 用户名 as username  from 系统_用户信息 where ID in (select 用户ID from 系统_角色成员 where 角色ID=:roleID)";
            OracleParameter[] prms = new OracleParameter[]
            {
                 new OracleParameter("roleID",OracleDbType.Varchar2,36) { Value=roleId}
            };
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
        }

        /// <summary>
        /// 查询出所有角色的名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRoleName()
        {
            string sql = "select ID,名称 as name from 系统_角色";
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 给用户分配角色也就是在角色成员表中添加数据
        /// </summary>
        /// <param name="username"></param>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public int AddRoleOfUser(string username,string roleId)
        {
            string sql = @"insert into 系统_角色成员(角色ID,用户ID) values(:roleID
                                  ,(select ID from 系统_用户信息 where 用户名 =:username'))";
            OracleParameter[] prms = new OracleParameter[]
             {
                 new OracleParameter("username",OracleDbType.Varchar2,36) { Value=username},
                 new OracleParameter("roleID",OracleDbType.Varchar2,36) { Value=roleId}
             };
            return OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);        
        }
    }
}
