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
    }
}
