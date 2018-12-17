using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //用户权限
    class UserPermission
    {
        public string roleId { get; set; }//角色ID
        public string menuId { get; set; }//菜单ID
        public string menuOperatingId { get; set; }//菜单操作ID
    }
}
