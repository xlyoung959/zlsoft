using Dao;
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
        public ContentResult QueryPatientsSpecial(int wardId)
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
        public ContentResult QueryPatientsInfo(string wardId)
        {
            var data = handoverReportService.QueryPatientsInfo(wardId);
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
        public int AddOrUpdateHandoverRecord(HandoverRecord handoverRecord)
        {
            return handoverReportService.AddOrUpdateHandoverRecord(handoverRecord);
        }
<<<<<<< HEAD
<<<<<<< HEAD

        public ContentResult QueryPatientInfoByID(string patientID, string wardID)
=======
=======
>>>>>>> e831f6658c3fcd5acbd49d62e2740e54e8240628
        /// <summary>
        /// 查询交班报告中的病人的id，床号，诊断情况
        /// </summary>
        /// <param name="wardID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ContentResult queryPatientInfoByID(string wardID, string date)
<<<<<<< HEAD
>>>>>>> e831f6658c3fcd5acbd49d62e2740e54e8240628
=======
>>>>>>> e831f6658c3fcd5acbd49d62e2740e54e8240628
        {
            var data = handoverReportService.SelectReportPatient(wardID, date);
            var dataStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(dataStr);
        }
    }
}