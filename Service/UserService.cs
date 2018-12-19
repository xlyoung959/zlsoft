using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Dao;

namespace Service
{
   public class UserService
    {
        private UserDao userDao =new UserDao();

        public int Login(string username,string password)
        {
            return userDao.Login(username, password);
        }


    }
}
