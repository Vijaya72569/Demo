using Microsoft.Data.SqlClient;

namespace RegisterForm.Models
{
    public class StudentRepository
    {
        private readonly string constring;
        public  StudentRepository(IConfiguration configuration)
        {
            constring = configuration.GetConnectionString("getcon")!;
        }
        public void Add(StudentModel student)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = @"Insert into Student(Name,Email,ContactNumber,Gender,Course,Hobbies,Skills) values(@Name,@Email,@ContactNumber,@Gender,@Course,@Hobbies,@Skills)";

           SqlCommand cmd=new SqlCommand(query, con);
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);

            cmd.Parameters.AddWithValue("@Course", student.Course);
            cmd.Parameters.AddWithValue("@Hobbies",string.Join(",",student.Hobbies ?? new List<string>()));
            cmd.Parameters.AddWithValue("@Skills",string.Join(",", student.Skills ?? new List<string>()));
           con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public List<StudentModel> GetStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Select * from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType= System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new StudentModel()
                {
                    Sid = Convert.ToInt32(reader["SiD"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNumber = Convert.ToInt64(reader["ContactNumber"]),
                    Gender = reader["Gender"].ToString(),
                    Course = reader["Course"].ToString(),
                    Hobbies = reader["Hobbies"].ToString()?.Split(",").ToList(),
                    Skills = reader["Skills"].ToString()?.Split(",").ToList()

                });
            }
            return students;

        }

        public void Update(StudentModel student)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = @"Update Student set Name=@Name,Email=@Email,ContactNumber=@ContactNumber,Gender=@Gender,Course=@Course,Hobbies=@Hobbies,Skills=@Skills  where Sid=@Sid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Sid",student.Sid);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Course", student.Course);
            cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", student.Hobbies ?? new List<string>()));
            cmd.Parameters.AddWithValue("@Skills", string.Join(",", student.Skills ?? new List<string>()));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = @"Delete  from Student  where Sid=@Sid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Sid", id);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
    }
}
