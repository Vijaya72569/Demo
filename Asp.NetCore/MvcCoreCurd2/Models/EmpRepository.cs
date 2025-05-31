using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;

namespace MvcCoreCurd2.Models
{
    

    public class EmpRepository
    {
        private readonly string constr;
        public EmpRepository() { 
        var dbconfig = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
        constr= dbconfig.GetConnectionString("SetConnection");

    }
        public void AddUser(EmpModel emp)
       // public void AddUser(EmpViewModel emp)
        {
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@city", emp.City);
               // string hobbies = emp.SelectedHobbies != null ? string.Join(",", emp.SelectedHobbies) : "";
                cmd.Parameters.AddWithValue("@hobbies", emp.Hobbies);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public List<EmpModel> GetAllEmps()
    {
        List<EmpModel> emps = new List<EmpModel>();
        using (SqlConnection con = new SqlConnection(constr))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_views", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                emps.Add(new EmpModel()
                {
                    Eid = Convert.ToInt32(dr["Eid"]),
                    Ename = Convert.ToString(dr["Ename"]),
                    Salary = Convert.ToDouble(dr["Salary"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    City = Convert.ToString(dr["City"]),
                    Hobbies = Convert.ToString(dr["Hobbies"])
                });
            }
        }
        return emps;
    }

        public void UpdateUser(EmpModel emp)
      //  public void UpdateUser(EmpViewModel emp)

        {
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("sp_edit1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@city", emp.City);
               // string hobbies = emp.SelectedHobbies != null ? string.Join(",", emp.SelectedHobbies) : "";
                cmd.Parameters.AddWithValue("@hobbies", emp.Hobbies);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteEmp(int id)
    {
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("sp_delete1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
}
    

