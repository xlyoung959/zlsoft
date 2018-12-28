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
   public class HandoverReportDao
    {
        /// <summary>
        ///  查询病人的特殊情况，就是病危病重的人
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <returns></returns>
        public DataTable QueryPatientsSpecial(int wardId)
        {
            string sql = @"select distinct a.病人Id as patientId ,a.主页id as homepageId,e.姓名 as name,a.出院病床 as bed,a.当前病况 as illState,c.诊断描述 as illness
                                     from 病案主页 a ,病人信息 e,病人诊断记录 c
                 where a.病人ID = e.病人ID and a.病人ID = c.病人ID  and a.当前病区id =:WardID and a.当前病况 in('重','危') and a.出院日期 is null order by  a.病人Id ";

            OracleParameter[] prms = new OracleParameter[]
            {
                 new OracleParameter("WardID",OracleDbType.Int32) { Value=wardId}
            };
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
        }

        /// <summary>
        /// 修改病人诊断记录表中的诊断描述
        /// </summary>
        /// <param name="patientId">病人ID</param>
        /// <param name="diagnostic">诊断描述</param>
        /// <returns>0,1</returns>
        public int ChangeDiagnosticDescription(int patientId, string diagnostic)
        {
            string sql = "update 病人诊断记录 set 诊断描述=:Diagnostic where 病人ID=:PatientId";
            OracleParameter[] prms = new OracleParameter[]
           {
                 new OracleParameter("Diagnostic",OracleDbType.Varchar2,100) { Value=diagnostic},
                  new OracleParameter("PatientId",OracleDbType.Int32) { Value=patientId}
           };
            return OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms); 
        }

    }
}
