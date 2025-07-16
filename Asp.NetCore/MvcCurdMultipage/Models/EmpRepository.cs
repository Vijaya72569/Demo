using Microsoft.Data.SqlClient;

namespace MvcCurdMultipage.Models
{
    public class EmpRepository
    {
        string constr;
       public EmpRepository(IConfiguration configuration)
        {
            constr = configuration.GetConnectionString("getcon")!;
        }
        public void AddUser(EmpModel emp)
        {

            SqlConnection con=new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("sp_Add1", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Empid);
            cmd.Parameters.AddWithValue("ename", emp.Ename);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("city", emp.City);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public List<EmpModel> GetEmps() 
        { 
         SqlConnection  conn=new SqlConnection(constr);
            List<EmpModel> obj=new  List<EmpModel>();
            SqlCommand cmd = new SqlCommand("sp_view", conn);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.Add(new EmpModel()
                {
                    Empid = Convert.ToInt32(dr["Empid"]),
                    Ename = Convert.ToString(dr["Ename"]),
                    Email = Convert.ToString(dr["Email"]),
                    City = Convert.ToString(dr["City"]),


                });         
            
            }
            return obj;
        
        }
        public void UpdateEmp(EmpModel emp)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", emp.Empid);
            cmd.Parameters.AddWithValue("ename", emp.Ename);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("city", emp.City);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmp(int id)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        }
    }

