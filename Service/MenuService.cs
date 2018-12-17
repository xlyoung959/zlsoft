using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

namespace Service
{
    public class MenuService
    {
        MenuDao menuDao = new MenuDao();

        public string getMenuList()
        {
            return "gfe";
        }
    }
}
