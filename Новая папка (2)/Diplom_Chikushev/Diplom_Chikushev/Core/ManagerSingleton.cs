using Diplom_Chikushev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Chikushev.Core
{
    public class ManagerSingleton
    {
        private static Manager _instance;

        public static Manager Instance()
        {
            if (_instance == null)
            {
                _instance = new Manager();
                return _instance;
            }
            return _instance;
        }

        public static Manager Instance(Manager manager)
        {
            if (_instance == null)
            {
                _instance = manager;
                return _instance;
            }
            return _instance;
        }
    }
}
