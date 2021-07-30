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
        public bool Login(UserModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("login", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@NameOrEmail", obj.Name);
            com.Parameters.AddWithValue("@Password", obj.Password);

            try
            {
                con.Open();
                int retVal = (int)com.ExecuteScalar();
                con.Close();
                if (retVal == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}