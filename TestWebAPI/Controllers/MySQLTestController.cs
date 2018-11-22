using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    public class MySQLTestController : ApiController
    {
        [Route("api/GetTestMySQL")]
        [HttpGet]
        public HttpResponseMessage GetTestMySQL(string Test_Name)
        {

            StringBuilder str = new StringBuilder();
            str.Append("[");
            DataTable temp = DataProject.MySqlCommands.GetData(Test_Name);
            foreach (DataRow row in temp.Rows)
            {
                str.Append("{\"Test_Id\":");
                str.Append("\"" + row["Test_Id"].ToString() + "\",");
                str.Append("\"Test_Name\":" + "\"" + row["Test_Name"].ToString() + "\",");
                str.Append("\"create_time\":" + "\"" + row["create_time"].ToString() + "\",");
                str.Append("\"remark\":" + "\"" + row["remark"].ToString() + "\"");
                str.Append("},");
            }
            str.Append("]");
            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(str.ToString(), Encoding.GetEncoding("UTF-8"), "application/json");
            return result;
            //return Json(new { data=temp});
        }

        [Route("api/GetTestMySQLNoCan")]
        [HttpGet]
        public HttpResponseMessage GetTestMySQLNoCan()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            DataTable temp = DataProject.MySqlCommands.GetData();
            foreach (DataRow row in temp.Rows)
            {
                str.Append("{\"Test_Id\":");
                str.Append("\"" + row["Test_Id"].ToString() + "\",");
                str.Append("\"Test_Name\":" + "\"" + row["Test_Name"].ToString() + "\",");
                str.Append("\"create_time\":" + "\"" + row["create_time"].ToString() + "\",");
                str.Append("\"remark\":" + "\"" + row["remark"].ToString() + "\"");
                str.Append("},");
            }
            str.Append("]");
            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(str.ToString(), Encoding.GetEncoding("UTF-8"), "application/json");
            return result;
        }
    }
}
