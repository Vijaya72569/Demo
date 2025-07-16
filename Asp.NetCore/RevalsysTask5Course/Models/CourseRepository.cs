using Microsoft.Data.SqlClient;

namespace RevalsysTask5Course.Models
{
    public class CourseRepository
    {
        string constr;
        public CourseRepository(IConfiguration configuration)

        {
            constr = configuration.GetConnectionString("getcon")!;
        }
        public void AddCourse(CourseModel course)
        {
            SqlConnection con = new SqlConnection(constr);
            string query = @"Insert into Course(CourseName,CourseCode,Description,CourseStartDate) values(@cname,@ccode,@description,@coursedate)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@cname", course.CourseName);
            cmd.Parameters.AddWithValue("@ccode", course.CourseCode);
            cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(course.Description) ? DBNull.Value : course.Description);
            cmd.Parameters.AddWithValue("@coursedate", course.CourseStartDate.HasValue ? course.CourseStartDate.Value : DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<CourseModel> GetAll()
        {
            List<CourseModel> list = new List<CourseModel>();
            SqlConnection con = new SqlConnection(constr);
            string query = "select * from Course";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new CourseModel()
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    CourseName = Convert.ToString(dr["CourseName"]),
                    CourseCode = Convert.ToString(dr["CourseCode"]),
                    Description = Convert.ToString(dr["Description"]),
                    CourseStartDate = dr["CourseStartDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CourseStartDate"])


                });

            }
            return list;
        }
        public bool CourseValid(string course)
        {

            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from course where CourseCode=@ccode";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@ccode", course);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            return count > 0;

        }
        public void EditCourse(CourseModel course)
        {
            SqlConnection con = new SqlConnection(constr);
            string query = @"Update  Course set CourseName=@cname,CourseCode=@ccode,Description=@description,CourseStartDate=@coursedate where CourseID=@cid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@cid", course.CourseId);
            cmd.Parameters.AddWithValue("@cname", course.CourseName);
            cmd.Parameters.AddWithValue("@ccode", course.CourseCode);
            cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(course.Description) ? DBNull.Value : course.Description);
            cmd.Parameters.AddWithValue("@coursedate", course.CourseStartDate.HasValue ? course.CourseStartDate.Value : DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public CourseModel CourseDetail(int id)
        {
            CourseModel course = new CourseModel();
            SqlConnection con = new SqlConnection(constr);
            string query = @"select * from Course where CourseID=@cid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@cid", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                course=new CourseModel()
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    CourseName = Convert.ToString(dr["CourseName"]),
                    CourseCode = Convert.ToString(dr["CourseCode"]),
                    Description = Convert.ToString(dr["Description"]),
                    CourseStartDate = dr["CourseStartDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CourseStartDate"])

                };
              
            }
            return course;
        }

        public void DeleteCourse(int id)
        {
            SqlConnection con = new SqlConnection(constr);
            string query = @"Delete from Course where CourseID=@cid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@cid", id);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}