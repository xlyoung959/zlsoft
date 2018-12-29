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

        /// <summary>
        /// 查询不同部门的病人信息，用于添加病人
        /// </summary>
        /// <param name="wardId">当前病区相关id</param>
        /// <returns></returns>
        public DataTable QueryPatientsInfo(string wardId)
        {
            string sql = @"select t.姓名 as name, t.住院号 as hospitalNum , t.床号 as bedId from PUB_病人基本信息 t where t.当前病区相关id=:WardId  and t.相关ID not in(
                              select distinct a.病人Id from 病案主页 a where a.当前病区id =:WardId  and a.当前病况 in('重','危') and a.出院日期 is null ) order by t.床号 ";
            OracleParameter[] prms = new OracleParameter[]
          {
                 new OracleParameter("WardID",OracleDbType.Varchar2,32) { Value=wardId}
          };
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);

        }

        /// <summary>
        /// 查询该病区所有病人的总人数
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public string QueryPatientsTotalNumber(string wardId)
        {
            string sql = " select count(*) from 病人信息 t where t.当前病区id =:WardId and t.出院时间 is null";
            OracleParameter[] prms = new OracleParameter[]
          {
                 new OracleParameter("WardID",OracleDbType.Varchar2,32) { Value=wardId}
          };
             string s=OracleHelper.ExecuteScalar(sql, CommandType.Text, prms);
            return s;
        }

        /// <summary>
        /// 向交班记录中添加数据
        /// </summary>
        /// <returns></returns>
        public int AddHandoverRecord(HandoverRecord handoverRecord)
        {
            string sql = @"insert into PUB_交班记录 (ID, 标题, 内容, 记录时间, 预留字段, 病区ID, 病人ID, 记录人, 是否作废)
                                  values(:ID, :Title, :Content, to_date(:RecordTime, 'yyyy-mm-dd hh24:mi:ss'), '1', :WardID, :PatientId, :RecordUser, 0); ";
            OracleParameter[] prms = new OracleParameter[]
         {
                 new OracleParameter("ID",OracleDbType.Varchar2,36) { Value=handoverRecord.id},
                 new OracleParameter("Title",OracleDbType.Varchar2,4000) { Value=handoverRecord.title},
                 new OracleParameter("Content",OracleDbType.Varchar2,4000) { Value=handoverRecord.content},
                 new OracleParameter("RecordTime",OracleDbType.Varchar2,36) { Value=handoverRecord.recordTime},
                 new OracleParameter("WardID",OracleDbType.Varchar2,4000) { Value=handoverRecord.wardId},
                 new OracleParameter("PatientId",OracleDbType.Varchar2,36) { Value=handoverRecord.patientId},                
                 new OracleParameter("RecordUser",OracleDbType.Varchar2,20) { Value=handoverRecord.recordUser}
         };
          return  OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
        }

        /// <summary>
        /// 修改交班记录里面的标题和，内容
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateHandoverRecord(string title,string content,string id)
        {
            string sql = "update PUB_交班记录 set 标题=:Title and 内容=:Content where ID=:ID";
            OracleParameter[] prms = new OracleParameter[]
           {
                 new OracleParameter("ID",OracleDbType.Varchar2,36) { Value=id},
                 new OracleParameter("Title",OracleDbType.Varchar2,4000) { Value=title},
                 new OracleParameter("Content",OracleDbType.Varchar2,4000) { Value=content}
           };
            return OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
     }

        /// <summary>
        /// 根据病人ID和记录的时间段(每个班次的时间)，来查询PUB_交班记录中的ID
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="recordTime"></param>
        /// <returns></returns>
        public string SelectPatientID(string patientId,string recordTime)
        {
            string sql = "select ID from PUB_交班记录 where 记录时间=to_date(:RecordTime,'yyyy-mm-dd hh24:mi:ss') and 病人ID=:PatientId";
            OracleParameter[] prms = new OracleParameter[]
          {
                 new OracleParameter("RecordTime",OracleDbType.Varchar2,36) { Value=recordTime},
                 new OracleParameter("PatientId",OracleDbType.Varchar2,32) { Value=patientId},
          };
            return OracleHelper.ExecuteScalar(sql, CommandType.Text, prms);

        }

    }
}
