using Microsoft.Data.SqlClient;
using System.Data;

namespace MVCCORECURD8._0.Models
{
    public class EmpRepository
    {

        string constring;
        public EmpRepository(IConfiguration configuration)
        {
            // Use the null-forgiving operator (!) if you’re sure it's never null:
            //  or
            // constring = configuration.GetConnectionString("getcon") 
            // ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null.");

            constring = configuration.GetConnectionString("getcon")!;
        }
        public void Adduser(EmpModel emp)
        {
            //var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json").Build();
            //string s = dbconfig.GetConnectionString("SetConnection");
            SqlConnection con = new SqlConnection(constring);
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
            //var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("appsettings.json").Build();
            //string s = dbconfig.GetConnectionString("SetConnection");
            List<EmpModel> emps = new List<EmpModel>();
            SqlConnection con = new SqlConnection(constring);
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
        public void UpdateUser(EmpModel emp)
        {
            //var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json").Build();
            //string s = dbconfig.GetConnectionString("SetConnection");
            //if (empviewmodel == null || empviewmodel==null )
            //{
            //    throw new ArgumentNullException(nameof(emp), "EmployeeViewModel or SelectedEmployee can not be null");
            //}
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("sp_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.Eid);
            cmd.Parameters.AddWithValue("@ename", emp.Ename);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmp(int id)
        {
            //var dbconfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //  .AddJsonFile("appsettings.json").Build();
            //string s = dbconfig.GetConnectionString("SetConnection");
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

