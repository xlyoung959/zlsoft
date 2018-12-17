using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //用户信息实体类
    class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int invalid { get; set; }//是否作废，默认为0,  1表示作废
        public string inputCode { get; set; }//输入码
        public string updateUser { get; set; }//修改用户
        public string updateTime { get; set; }//修改日期
        public string invalidTime { get; set; }//作废日期
        public int contrast { get; set; }//是否对照 默认是1
        public string relatedID { get; set; }//相关ID
        public string employeeID { get; set; }//职工相关ID
    }
}
