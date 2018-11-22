using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataProject
{
    public class MySqlCommands
    {
        public static DataTable GetData(string name)
        {
            string sql = @"SELECT * FROM mytesttable where Test_Name=?Name";
            MySqlParameter[] parms= {
                new MySqlParameter("?Name", MySqlDbType.VarChar, 200),
            };
            parms[0].Value = name;
            DataTable table = DbHelperForMySQL.Query(sql,parms).Tables[0];
            return table;
        }

        public static DataTable GetData()
        {
            string sql = @"select * from mytesttable";
            DataTable table = DbHelperForMySQL.Query(sql).Tables[0];
            return table;
        }
    }
}
