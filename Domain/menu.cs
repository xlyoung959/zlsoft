using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //菜单实体类 
    class Menu
    {
        public string id { get; set; }//ID
        public string code { get; set; }//编码
        public string name { get; set; }//名称
        public string moduleCode { get; set; }//模块代码
        public string explanation { get; set; }//说明
        public string parentId { get; set; }//上级ID
        public int level { get; set; }//层级 默认1
        public int finalNode = 0;//末级 默认为0
        public string functionId { get; set; }//功能ID
        public string icon { get; set; }//图标
        public string parameter { get; set; } //参数值
        public int openWay { get; set; }//打开方式，默认1
        public int startPermission { get; set; } //是否启用权限 默认0
        public int invalid { get; set; }//是否作废 默认0
        public string invalidTime { get; set; }//作废时间
        public string inputCode { get; set; }//输入码
        public string updateUser { get; set; }//修改用户
        public string updateTime { get; set; }//修改时间
        public int? sort { get; set; }//排序序号
        public int mobileUser { get; set; } //移动使用
        public int relatedFunction { get; set; }//是否关联功能默认为0

    }
}
