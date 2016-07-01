using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DoctorOffline.Service
{
    public class BaseService
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection("Data Source=127.0.0.1;Initial Catalog=doctor;Persist Security Info=True;User ID=root;Password=ganggang");
            return con;
        }
    }
}
