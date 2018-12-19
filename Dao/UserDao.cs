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
    }
}
