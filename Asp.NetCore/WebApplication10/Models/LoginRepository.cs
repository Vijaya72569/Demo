using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApplication10.Models
{
    public class LoginRepository
    {
        public bool CheckUser(string uname,string pwd)
        {
            var decon = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string s = decon["getcon:setconnection"];
            bool flag = false;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_check", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", uname);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            con.Open();
            flag = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return flag;
        }
    }
}
