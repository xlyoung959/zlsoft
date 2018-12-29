using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    /// <summary>
    ///交班记录 
    ///ID, 标题, 内容, 记录时间, 预留字段, 病区ID, 病人ID, 记录人, 是否作废
    /// </summary>
   public class HandoverRecord
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string recordTime { get; set; }
        public string reserved { get; set; }
        public string patientId { get; set; }
        public string wardId { get; set; }
        public string recordUser { get; set; }
        public int invalid = 0;
    }
}
