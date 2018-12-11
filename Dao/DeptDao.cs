using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

using Oracle.DataAccess.Client;
using System.Data;

namespace Dao
{
  
    public class DeptDao
    {
        
        /// <summary>
        /// 新增组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>int操作的行数</returns>
        public int insertDept(Dept dept)
        {
            string sql = "insert into 部门表 values(deptid_seq.nextval,:上级ID,:编码,:名称,:简码,:位置,:末级,:建档时间,:撤档时间,:站点,:环境类别,:部门负责人,:最后修改时间,:顺序,:别名)";
            OracleParameter[] prms = new OracleParameter[]
            {
             new OracleParameter("上级ID",OracleDbType.Int32,10) { Value=dept.上级ID},
             new OracleParameter("编码",OracleDbType.Varchar2,10) { Value=dept.编码},
             new OracleParameter("名称",OracleDbType.Varchar2,100) { Value=dept.名称},
             new OracleParameter("简码",OracleDbType.Varchar2,100) { Value=dept.简码},
             new OracleParameter("位置",OracleDbType.Varchar2,50) { Value=dept.位置},
             new OracleParameter("末级",OracleDbType.Int32,1) { Value=dept.末级},
             new OracleParameter("建档时间",OracleDbType.Date) { Value=dept.建档时间},
             new OracleParameter("撤档时间",OracleDbType.Date) { Value=null},
             new OracleParameter("站点",OracleDbType.Varchar2,1) { Value=dept.站点},
             new OracleParameter("环境类别",OracleDbType.Varchar2,10) { Value=dept.环境类别},
             new OracleParameter("部门负责人",OracleDbType.Int32,10) { Value=null},
             new OracleParameter("最后修改时间",OracleDbType.Date) { Value=null},
             new OracleParameter("顺序",OracleDbType.Int32,10) { Value=null},
             new OracleParameter("别名",OracleDbType.Varchar2,10) { Value=null}
            };
            int r =  OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
            return r;
        }

        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>操作的行数</returns>
        public int updateDept(Dept dept)
        {
            string sql = "update 部门表 set 上级ID=:上级ID,编码=:编码,名称=:名称,简码=:简码,位置=:位置,末级=:末级,站点=:站点,环境类别=:环境类别,最后修改时间=:最后修改时间 where ID=:ID";
            OracleParameter[] prms = new OracleParameter[]
                {
                 new OracleParameter("上级ID",OracleDbType.Int32,10) { Value=dept.上级ID},
                 new OracleParameter("编码",OracleDbType.Varchar2,10) { Value=dept.编码},
                 new OracleParameter("名称",OracleDbType.Varchar2,100) { Value=dept.名称},
                 new OracleParameter("简码",OracleDbType.Varchar2,100) { Value=dept.简码},
                 new OracleParameter("位置",OracleDbType.Varchar2,50) { Value=dept.位置},
                 new OracleParameter("末级",OracleDbType.Int32,1) { Value=dept.末级},
                 new OracleParameter("站点",OracleDbType.Varchar2,1) { Value=dept.站点},
                 new OracleParameter("环境类别",OracleDbType.Varchar2,10) { Value=dept.环境类别},
                 new OracleParameter("最后修改时间",OracleDbType.Date) { Value=dept.最后修改时间},
                 new OracleParameter("ID",OracleDbType.Int32,10) { Value=dept.ID}
                };
            int r = OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
            return r;
        }
    }
}
