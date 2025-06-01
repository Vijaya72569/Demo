using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WebAppAssign.Models
{
    public class CustRepository
    {
        public void AddUser(CustomerModel obj)
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string s = dbconfig["getcon:setconnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_Ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", obj.Username);
            cmd.Parameters.AddWithValue("@pwd", obj.Password);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@selectedhobbies", obj.SelectedHobbies);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
