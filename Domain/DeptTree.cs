using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeptTree
    {
        //ztree的target属性值设置为content
        public  string target = "content";
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        //设置是否是父节点，方便前端ztree展开
        public bool isParent { get; set; }
        
        public List<DeptTree> children { get; set; }

    }
}
