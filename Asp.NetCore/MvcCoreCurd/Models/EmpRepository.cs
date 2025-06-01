using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
namespace MvcCoreCurd.Models
{
    public class EmpRepository
    {

         public void AddUser(EmpModel emp)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            // string s = dbconfig["getcon:DefaultConnection"];
            string s = dbconfig.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_add", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateUser(EmployeeViewModel emp)
        {
            if (emp == null || emp.SelectedEmployee == null)
            {
                throw new ArgumentNullException(nameof(emp), "EmployeeViewModel or SelectedEmployee cannot be null.");
            }

            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            //  string s = dbconfig["getcon:DefaultConnection"];
            string s = dbconfig.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.SelectedEmployee.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.SelectedEmployee.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.SelectedEmployee.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<EmpModel> GetEmps()
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            //  string s = dbconfig["getcon:DefaultConnection"];
            string s = dbconfig.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(s);
            List<EmpModel> list = new List<EmpModel>();
            
            SqlCommand cmd = new SqlCommand("sp_view", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new EmpModel()
                {
                      Eid = Convert.ToInt32(dr["Eid"]),
                 
                    Ename = Convert.ToString(dr["Ename"]),
                    Salary = Convert.ToDouble(dr["Salary"])
                });
            }
           
            return list;
        }

        public void Delete(int id)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            //  string s = dbconfig["getcon:DefaultConnection"];
            string s = dbconfig.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public Models.EmpModel SearchEmp(Models.EmpModel emp)
        //{
        //    var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json").Build();
        //    // string s = dbconfig["getcon:DefaultConnection"];
        //    string s = dbconfig.GetConnectionString("DefaultConnection");
        //    SqlConnection con = new SqlConnection(s);
        //    SqlCommand cmd = new SqlCommand("sp_search", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@eid", emp.Eid);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.HasRows)
        //    {


        //        while (reader.Read())
        //        {
        //            emp.Ename = reader[1].ToString();
        //            emp.Salary = Convert.ToDouble(reader[2]);

        //        }
        //    }
        //    return emp;
        //}
    }
}
