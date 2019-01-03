﻿using Dao;
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
               return handoverReportDao.AddHandoverRecord(handoverRecord);
            }
            else
            {
               return handoverReportDao.UpdateHandoverRecord(handoverRecord.title, handoverRecord.content, id);
            }
        }

        //想交班记录中添加信息，主要是添加病人时，数据库肯定无该条数据，只能添加
        public int AddHandoverRecord(HandoverRecord handoverRecord)
        {
            return handoverReportDao.AddHandoverRecord(handoverRecord);
        }

        /// <summary>
        /// 根据病人id查询病人的id，床号,姓名,诊断情况
        /// </summary>
        /// <param name="wardID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DataTable> SelectReportPatient(string wardID, string date)
        {
            DataTable dt = handoverReportDao.SelectReportPatientID(wardID, date);
            DataTable d = new DataTable();
            List<DataTable> list = new List<DataTable>();
            foreach (var dr in dt.Rows)
            {
                
                d = handoverReportDao.SelectPatientInfoByID(dr.ToString());
                 list.Add(d);
            }
            return list;
        }

    }
}
