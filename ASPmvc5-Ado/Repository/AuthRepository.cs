using ASPmvc5_Ado.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPmvc5_Ado.Repository
{
    public class AuthRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        //To Register   
        public bool Register(UserModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("register", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Password", obj.Password);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To Register   
        public string Login(UserModel obj)
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();


            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new EmpModel
                    {
                        Empid = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                );
            }
            return "asd";
            //SqlCommand com = new SqlCommand("login", con);
            //com.CommandType = CommandType.StoredProcedure;

            //com.Parameters.AddWithValue("@NameOrEmail", obj.Name);
            //com.Parameters.AddWithValue("@Password", obj.Password);

            //con.Open();
            //int i = com.ExecuteNonQuery();
            //con.Close();
            //return i.ToString();

            //if (i >= 1)
            //{
            //return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}