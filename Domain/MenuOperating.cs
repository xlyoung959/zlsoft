using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //菜单操作
    class MenuOperating
    {
        public string id { get; set; }
        public string menuId { get; set; }//菜单ID
        public int? sort { get; set; }//排序序号
        public int permission { get; set; } //是否控制权限 默认为0
        public string updateUser { get; set; }//修改用户
        public string updateTime { get; set; }//修改时间
        public string operationCode { get; set; }//操作代码
        public string functionId { get; set; }//功能操作ID
    }
}
