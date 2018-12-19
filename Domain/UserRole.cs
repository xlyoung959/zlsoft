using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //用户成员（用户角色）
    class UserRole
    {
        public string roleId { get; set; }//角色ID 
        public string userId { get; set; }//用户ID
        public string updateUser { get; set; }//修改用户
        public string updateTime { get; set; }//修改时间
        public int? sort { get; set; }//排序序号
    }
}
