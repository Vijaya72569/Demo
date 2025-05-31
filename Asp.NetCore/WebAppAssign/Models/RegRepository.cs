using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAppAssign.Models
{
    public class RegRepository
    {
       
        public void AddUser(RegModel obj)
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string s = dbconfig["getcon:setconnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_Add", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", obj.Username);
            cmd.Parameters.AddWithValue("@pwd", obj.Password);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@music", obj.Music);
            cmd.Parameters.AddWithValue("@crafts", obj.Crafts);
            cmd.Parameters.AddWithValue("@reading", obj.Reading);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
