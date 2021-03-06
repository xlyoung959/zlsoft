﻿using Dao;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace case1.Controllers
{
    public class HandoverReportController : Controller
    {
        private HandoverReportService handoverReportService=new HandoverReportService();
        // GET: HandoverReport
        public ActionResult Report()
        {
            return View("Report");
        }
        /// <summary>
        /// 查询病人的特殊情况，就是病危病重的人
        /// </summary>
        /// <returns></returns>
        public ContentResult QueryPatientsSpecial(string wardId)
        {
            var data = handoverReportService.QueryPatientsSpecial(wardId);
             var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

        /// <summary>
        /// 修改病人的诊断描述
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="diagnostic"></param>
        /// <returns></returns>
        public int ChangeDiagnosticDescription(int patientId, string diagnostic)
        {
            return handoverReportService.ChangeDiagnosticDescription(patientId, diagnostic);
        }

        /// <summary>
        /// 查询病人的一些基本信息，用户添加病人信息
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public ContentResult QueryPatientsInfo(string wardId,string pIds)
        {
            var data = handoverReportService.QueryPatientsInfo(wardId, pIds);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }
        public ContentResult QueryPatientsInfoByName(string wardId, string searchText)
        {
            var data= handoverReportService.QueryPatientsInfoByName(wardId, searchText);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

        /// <summary>
        ///某个病区病人的总人数
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public string QueryPatientsTotalNumber(string wardId)
        {
            return handoverReportService.QueryPatientsTotalNumber(wardId);
        }

        /// <summary>
        /// 添加病人里面的确认按钮点击后，往交班记录中添加数据
        /// </summary>
        /// <param name="handoverRecord"></param>
        /// <returns></returns>
        public int AddHandoverRecordTitle(string title,string wardId,string patientId,string recordUser)
        {
            HandoverRecord handoverRecord = new HandoverRecord();
            handoverRecord.title = title;
            handoverRecord.wardId = wardId;
            handoverRecord.patientId = patientId;
            handoverRecord.recordUser = recordUser;
            return handoverReportService.AddHandoverRecordTitle(handoverRecord);
        }
        /// <summary>
        /// 添加或者修改交班记录表中的信息
        /// </summary>
        /// <param name="handoverRecord"></param>
        /// <returns></returns>
        public int AddOrUpdateHandoverRecord(string content, string recordTime,string wardId, string patientId, string recordUser)
        {
            HandoverRecord handoverRecord = new HandoverRecord();
            handoverRecord.content = content;
            handoverRecord.recordTime = recordTime;
            handoverRecord.wardId = wardId;
            handoverRecord.patientId = patientId;
            handoverRecord.recordUser = recordUser;
            return handoverReportService.AddOrUpdateHandoverRecord(handoverRecord);
        }


        /// <summary>
        /// 查询交班报告中的病人的id，床号，诊断情况
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="dtime"></param>
        /// <returns></returns>
        public ContentResult QueryPatientInfoByID(string wardId,string dTime)
        {
            var data = handoverReportService.SelectReportPatient(wardId, dTime);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }
        /// <summary>
        /// 查询交班记录中病人的内容，用于放在当前日期，某个班次中，显示病人的基本情况
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="date"></param>
        /// <param name="wardID"></param>
        /// <returns></returns>
        public ContentResult QueryPatientContentByID(string patientID, string date, string wardID)
        {
            var data = handoverReportService.SelectPatientContent( patientID,date,wardID);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

        /// <summary>
        /// 实现交班功能
        /// </summary>
        /// <returns></returns>
        public int HandOver(string wordId, string submitTime, string username, string editContent, string editTime)
        {
            return handoverReportService.HandOver(wordId, submitTime, username, editContent, editTime);
        }

        /// <summary>
        /// 取消交班
        /// </summary>
        /// <param name="submitTime"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public int CancelHandOver(string submitTime, string username)
        {
            return handoverReportService.CancelHandOver(submitTime, username);
        }

        //接班
        public int Succession(string wordId, string submitTime, string username)
        {
            return handoverReportService.Succession(wordId, submitTime, username);
        }

        //取消接班
        public int CancelSuccession(string submitTime, string username)
        {
            return handoverReportService.CancelSuccession(submitTime, username);
        }

        //判断当前是否已交班
        public ContentResult  IsHandOver(string wordId, string submitTime)
        {
           var data =handoverReportService.IsHandOver(wordId, submitTime);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);

        }
        //判断是否已接班
        public ContentResult IsSuccession(string wordId, string submitTime)
        {
            var data = handoverReportService.IsSuccession(wordId, submitTime);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }

    }
}