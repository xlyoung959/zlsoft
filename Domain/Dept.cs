using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Dept
    {
        
        public string ID { get; set; }
        public string parentId { get; set; }   //上级ID
        public string code { get; set; }      //编码
        public string name { get; set; }     //姓名
        public string 简码 { get; set; }
        public string 位置 { get; set; }
        public string 末级 { get; set; }
        public string 建档时间 { get; set; }

        public string 撤档时间 { get; set; }
        public string 站点 { get; set; }
        public string 环境类别 { get; set; }

        public string 部门负责人 { get; set; }

        public string 最后修改时间 { get; set; }
        public string 顺序 { get; set; }

    }
}
