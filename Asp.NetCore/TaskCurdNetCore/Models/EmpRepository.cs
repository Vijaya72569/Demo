using Microsoft.Data.SqlClient;

namespace TaskCurdNetCore.Models
{
    public class EmpRepository
    {
        string constring;
        public EmpRepository(IConfiguration configuration)
        {
            constring = configuration.GetConnectionString("getcon")!;
        }
        public void AddEmp(EmpModel emp)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "insert into Emp(FirstName,LastName,Gender,Email,Mobile) values (@fname,@lname,@gender,@email,@mobile)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@fname", emp.FirstName);
            cmd.Parameters.AddWithValue("@lname", string.IsNullOrWhiteSpace(emp.LastName) ? DBNull.Value : emp.LastName);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<EmpModel> GetEmpList()
        {
            List<EmpModel> list = new List<EmpModel>();
            SqlConnection con = new SqlConnection(constring);
            string query = "select * from Emp";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new EmpModel()
                {
                    Eid = Convert.ToInt32(dr["Eid"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    Email = Convert.ToString(dr["Email"]),
                    Mobile = Convert.ToInt64(dr["Mobile"]),
                });
            }
            return list;
        }

        public void EditEmp(EmpModel emp)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "update Emp set FirstName=@fname,LastName=@lname,Gender=@gender,Email=@email,Mobile=@mobile where Eid=@eid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@eid", emp.Eid);
            cmd.Parameters.AddWithValue("@fname", emp.FirstName);
            cmd.Parameters.AddWithValue("@lname", string.IsNullOrWhiteSpace(emp.LastName) ? DBNull.Value : emp.LastName);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmp(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "delete from Emp where Eid=@eid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@eid", id);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
