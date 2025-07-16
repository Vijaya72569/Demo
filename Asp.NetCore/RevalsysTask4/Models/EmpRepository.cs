using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace RevalsysTask4.Models
{
    public class EmpRepository
    {
        string constring;
        public EmpRepository(IConfiguration configuration)
        {
            constring = configuration.GetConnectionString("getcon")!;
        }
        public List<EmpModel> GetAll()
        {
            List<EmpModel> list = new List<EmpModel>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_view", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new EmpModel()
                {
                    EmpId = Convert.ToInt32(reader["EmpId"]),//System.IndexOutOfRangeException: 'EmpId'
                    FirstName = reader["FirstName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Mobile =reader["Mobile"]!=DBNull.Value ? Convert.ToInt64(reader["Mobile"]):0,
                    CountryName = reader["CountryName"].ToString(),
                    StateName = reader["CountryName"].ToString(),

                });
            }
            return list;

        }
        public List<SelectListItem> GetCountries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getCountries", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SelectListItem()
                {
                   Value=reader["CountryId"].ToString(),
                   Text=reader["CountryName"].ToString(),

                });
            }
            return list;


        }

        public List<SelectListItem> GetStates(int countryId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getStateByCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", countryId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SelectListItem()
                {
                    Value = reader["StateId"].ToString(),
                    Text = reader["StateName"].ToString(),

                });
            }
            return list;


        }
        public void Add(EmpModel emp)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_add", con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile.HasValue ? emp.Mobile.Value : DBNull.Value );
            cmd.Parameters.AddWithValue("@CountryId", emp.CountryId);
            cmd.Parameters.AddWithValue("@StateId", emp.StateId);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Update(EmpModel emp)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_edit", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Eid", emp.EmpId);
            cmd.Parameters.AddWithValue("@fname", emp.FirstName);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile.HasValue ? emp.Mobile.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Cid", emp.CountryId);
            cmd.Parameters.AddWithValue("@Sid", emp.StateId);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
           
            cmd.ExecuteNonQuery();
            con.Close();

        }
       

    }
}
