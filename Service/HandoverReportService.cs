using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class HandoverReportService
    {
        private HandoverReportDao handoverReportDao=new HandoverReportDao();

        /// <summary>
        /// 查询病人的特殊情况，就是病危病重的人
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable QueryPatientsSpecial(int wardId)
        {
            return handoverReportDao.QueryPatientsSpecial(wardId);
        }

        /// <summary>
        /// 修改病人的诊断描述
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="diagnostic"></param>
        /// <returns></returns>
        public int ChangeDiagnosticDescription(int patientId, string diagnostic)
        {
            return handoverReportDao.ChangeDiagnosticDescription(patientId, diagnostic);
        }

        /// <summary>
        /// 查询病人的基本信息，用户在添加病人那里显示
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable QueryPatientsInfo(string wardId)
        {
            return handoverReportDao.QueryPatientsInfo(wardId);
        }

        public DataTable QueryPatientsInfoByName(string wardId, string searchText)
        {
            return handoverReportDao.QueryPatientsInfoByName(wardId, searchText);
        }

        /// <summary>
        /// 查询病人在院在该病区的总人数
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public string QueryPatientsTotalNumber(string wardId)
        {
            return handoverReportDao.QueryPatientsTotalNumber(wardId);
        }

        /// <summary>
        /// 在交班记录表中有无该条记录，有添加就修改无则添加，先判断
        /// </summary>
        /// <returns></returns>
        public int AddOrUpdateHandoverRecord(HandoverRecord handoverRecord)
        {
            string id = handoverReportDao.SelectPatientID(handoverRecord.patientId,handoverRecord.recordTime);
            //有数据修改，没有数据则添加
            if (id == null)
            {
               return handoverReportDao.AddHandoverRecordContent(handoverRecord);
            }
            else
            {
               return handoverReportDao.UpdateHandoverRecordContent(handoverRecord.content, id);
            }
        }

        //向交班记录中添加信息，主要是添加病人时，数据库肯定无该条数据，只能添加，而且只添加标体
        public int AddHandoverRecordTitle(HandoverRecord handoverRecord)
        {
            return handoverReportDao.AddHandoverRecordTitle(handoverRecord);
        }

    }
}
