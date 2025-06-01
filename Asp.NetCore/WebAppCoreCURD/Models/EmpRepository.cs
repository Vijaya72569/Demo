using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;

namespace WebAppCoreCURD.Models
{
    public class EmpRepository
    {
        public void AddUser(EmpModel em)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string s = dbconfig["getcon:SetConnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cm = new SqlCommand("sp_Add1", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", em.Empid);
            cm.Parameters.AddWithValue("@ename", em.Ename);
            cm.Parameters.AddWithValue("@email", em.Email);
            cm.Parameters.AddWithValue("@city", em.City);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public List<EmpModel> GetEmpAll()
        {
            var dbcon = new 
            ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
            AddJsonFile("appsettings.json").Build();
            string s = dbcon["getcon:SetConnection"];
            SqlConnection con = new SqlConnection(s);
            List<EmpModel> obj = new List<EmpModel>();
            SqlCommand cm = new SqlCommand("sp_view", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                obj.Add(new EmpModel()
                {
                    Empid = Convert.ToInt32(dr["Empid"]),
                    Ename = Convert.ToString(dr["Ename"]),
                    Email = Convert.ToString(dr["Email"]),
                    City = Convert.ToString(dr["City"])
                }
                );
            }
            return obj;
        }
        public void Update(EmpModel em)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string s = dbconfig["getcon:SetConnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cm = new SqlCommand("sp_update", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@eid", em.Empid);
            cm.Parameters.AddWithValue("@ename", em.Ename);
            cm.Parameters.AddWithValue("@email", em.Email);
            cm.Parameters.AddWithValue("@city", em.City);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int eno)
        {
            var dbconfig = new 
                ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string s = dbconfig["getcon:SetConnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cm = new SqlCommand("sp_delete", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@eid", eno);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}
