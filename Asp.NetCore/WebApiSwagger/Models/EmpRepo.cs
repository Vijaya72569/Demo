using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApiSwagger.Models
{
    public class EmpRepo
    {
        private readonly string constring;
        public EmpRepo(IConfiguration configuration)
        {
            constring = configuration.GetConnectionString("getcon")!;
        }
        public void Add(Emp emp)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "Insert into Emp (Name,Salary,Phone) Values(@name,@sal,@phno)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@phno", emp.Phone);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Emp> GetAll()
        {
            List<Emp> emps = new List<Emp>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "select * from emp";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emps.Add(new Emp()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Salary = Convert.ToDecimal(reader["Salary"]),
                    Phone = Convert.ToInt64(reader["Phone"])

                });
            }
            return emps;
        }

        public void Update(Emp emp)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "Update Emp Set Name=@name,Salary=@sal,Phone=@phno where Id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@phno", emp.Phone);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "Delete from Emp where Id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public Emp GetEmp(int id)
        {
            Emp emp = new Emp();
            SqlConnection con = new SqlConnection(constring);
            string query = "select * from Emp where Id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        Phone = Convert.ToInt64(reader["Phone"])

                    };
                }
                reader.Close();
            }
            return emp;
        }
    }
}

