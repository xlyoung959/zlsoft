using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //角色实体表
    class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        public int invalid { get; set; }//是否作废，默认为0
        public string invalidTime { get; set; }//作废时间
        public string updateUser { get; set; }//修改用户
        public string updateTime { get; set; }//修改时间
        public string moduleCode { get; set; }//模块代码
        public  string userType { get; set; }//用户组类型 默认'0'
        public string inputCode { get; set; }//输入码
        public int? sort { get; set; }//排序序号
        public string defaultFunction { get; set; } //默认载入功能
       public string mobileDefaultFunction { get; set; } //移动端默认载入功能

    }
}
