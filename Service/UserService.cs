using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Dao;
using System.Data;

namespace Service
{
   public class UserService
    {
        private UserDao userDao =new UserDao();

        //登录
        public int Login(string username,string password)
        {
            return userDao.Login(username, password);
        }

        public DataTable GetUserNotRole(string roleId)
        {
            return userDao.GetUserNotRole(roleId);
        }
        public DataTable GetUserHaveRole(string roleId)
        {
            return userDao.GetUserHaveRole(roleId);
        }

        public DataTable GetAllRoleName()
        {
            return userDao.GetAllRoleName();
        }

        //添加角色成员表中的数据，给用户分配角色
        public int AddRoleOfUser(string username, string roleId)
        {
            return userDao.AddRoleOfUser(username, roleId);
        }

        public int MoveRoleOfUser(string username, string roleId)
        {
            return userDao.MoveRoleOfUser(username, roleId);
        }

    }
}
