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


    }
}