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
        public DataTable QueryPatientsSpecial(string wardId)
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
            if (handoverReportDao.ChangeDiagnosticDescription(patientId, diagnostic) > 0)
            {
                return 1;
            }
            else
            {
                return handoverReportDao.AddDiagnosticDescription(patientId, diagnostic);
            }
        }

        /// <summary>
        /// 查询病人的基本信息，用户在添加病人那里显示
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable QueryPatientsInfo(string wardId, string pIds)
        {
            return handoverReportDao.QueryPatientsInfo(wardId, pIds);
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
            foreach (DataRow dr in dt.Rows)
            {
                
                d = handoverReportDao.SelectPatientInfoByID(dr.Field<string>("PATIENTID"));
                 list.Add(d);
            }
            return list;
        }

        public DataTable SelectPatientContent(string patientID, string date, string wardID)
        {
            return handoverReportDao.SelectPatientContentByID(patientID, date, wardID);
        }
        //交班
        public int HandOver(string wordId, string submitTime, string username, string editContent, string editTime)
        {
            return handoverReportDao.HandOver(wordId, submitTime, username, editContent, editTime);
        }
        //取消交班
        public int CancelHandOver(string submitTime, string username)
        {
            return handoverReportDao.CancelHandOver(submitTime, username);
        }
        //接班
        public int Succession(string wordId, string submitTime, string username)
        {
            return handoverReportDao.Succession(wordId, submitTime, username);
        }
        //取消接班
        public int CancelSuccession(string submitTime, string username)
        {
            return handoverReportDao.CancelSuccession(submitTime, username);
        }
        //判断当前是否已交班
        public DataTable IsHandOver(string wordId, string submitTime)
        {
            return handoverReportDao.IsHandOver(wordId, submitTime);
        }
        //判断是否已接班
        public DataTable IsSuccession(string wordId, string submitTime)
        {
            return handoverReportDao.IsSuccession(wordId, submitTime);
        }
    }
}
