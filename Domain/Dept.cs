using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Dept
    {
        
        public int Id { get; set; }
        public int? parentId { get; set; }   //上级ID
        public string code { get; set; }       //编码
        public string name { get; set; }      //姓名
        public string simCode { get; set; }   //简码
        public string location { get; set; }  //位置
        public int finalNode { get; set; }  //末级
        public string createTime { get; set; } //建档时间
        public string deleteTime { get; set; } //撤档时间
        public string site { get; set; }   //站点
        public string envCat { get; set; } //环境类别 environment category
        public int? deptId { get; set; } //部门负责人
        public string lastTime { get; set; }//最后修改时间
        public int? sort { get; set; }  //排序
        public string otherName { get; set; } //别名
    }
}
