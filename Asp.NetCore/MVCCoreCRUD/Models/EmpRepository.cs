using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MVCCoreCRUD.Models
{
    public class EmpRepository
    {
        private readonly string constr;
        public EmpRepository() {
            var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            constr = dbconfig.GetConnectionString("SetConnection");
        }
        public void AddUser(EmpModel emp) 
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.Eid);
                cmd.Parameters.AddWithValue("@ename", emp.Ename);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@city", emp.City);
                cmd.Parameters.AddWithValue("@hobbies", emp.Hobbies);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<EmpModel> GetAllEmps()
        {
            List<EmpModel> obj=new List<EmpModel>();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("sp_views", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new EmpModel()
                {
                    Eid = Convert.ToInt32(dr["Eid"]),
                    Ename=Convert.ToString(dr["Ename"]),
                    Salary = Convert.ToDouble(dr["Salary"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    City = Convert.ToString(dr["City"]),
                    Hobbies = Convert.ToString(dr["Hobbies"])

                });
            }
            return obj;

        }

        public void UpdateUser(EmpModel emp)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_edit1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.Eid);
                cmd.Parameters.AddWithValue("@ename", emp.Ename);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@city", emp.City);
                cmd.Parameters.AddWithValue("@hobbies", emp.Hobbies);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

       public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_delete1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

    }
}
