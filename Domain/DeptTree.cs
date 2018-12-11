using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeptTree
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        public bool isParent { get; set; }
        public List<DeptTree> children { get; set; }

    }
}
