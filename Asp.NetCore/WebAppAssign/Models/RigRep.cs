using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Extensions.Hosting;
namespace WebAppAssign.Models
{
    public class RigRep
    {
        public void AddUs( Register obj)
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string s = dbconfig["getcon:setconnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", obj.Username);
            cmd.Parameters.AddWithValue("@pwd", obj.Password);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            string hobby = "";
           
                if (obj.Crafts == true)
                {
                    hobby = "Crafts";
                }
                if (obj.Music == true)
                {
                    hobby = hobby +","+ "Music";
                }
                if (obj.Reading == true)
                {
                    hobby = hobby +","+ "Reading";
                }
            
            obj.Hobbies = hobby;

            cmd.Parameters.AddWithValue("@hobbies", obj.Hobbies);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
