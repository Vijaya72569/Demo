using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MvcCoreCurdOperations.Models
{
    public class EmpRepository
    {
        public void Adduser(EmpModel emp)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string s = dbconfig.GetConnectionString("SetConnection");
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
        public List<EmpModel> GetAllEmps()
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            string s = dbconfig.GetConnectionString("SetConnection");
            List<EmpModel> emps = new List<EmpModel>();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_view", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emps.Add(new EmpModel()
                {
                    Eid = Convert.ToInt32(dr["Eid"]),
                    Ename = Convert.ToString(dr["Ename"]),
                    Salary = Convert.ToDouble(dr["Salary"])

                });
            }
            return emps;
        }
        public void UpdateUser(EmployeeViewModel emp)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json").Build();
            string s = dbconfig.GetConnectionString("SetConnection");
            if(emp==null || emp.SelectedEmplyee == null)
            {
                throw new ArgumentNullException(nameof(emp),"EmployeeViewModel or SelectedEmployee can not be null");
            }
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.SelectedEmplyee.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.SelectedEmplyee.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.SelectedEmplyee.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmp(int id)
        {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json").Build();
            string s = dbconfig.GetConnectionString("SetConnection");
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
