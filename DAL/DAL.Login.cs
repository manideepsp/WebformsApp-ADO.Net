﻿using DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    /// <summary>
    /// The dll login.
    /// </summary>
    internal class Login : ILogin
    {
        /// <summary>
        /// Is login success.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool IsLoginSuccess(User user)
        {
            string constr = ConfigurationManager.ConnectionStrings["Ashish_db"].ConnectionString;
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand(SqlCRUDOperations.SelectWithUsername, connection);
            command.Parameters.AddWithValue("UserName", user.UserName);

            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            try
            {
                DataRow dr = dt.Rows[0];
                string dbPassword = Encoding.UTF8.GetString((byte[])dr["Password"]);
                Console.WriteLine(dbPassword);

                // Verify the password text with the generated hash stored in database
                if (dr["UserName"].ToString() == user.UserName && BCrypt.Net.BCrypt.Verify(user.Password, dbPassword))
                {
                    return true; //Login successful
                }
                return false; //Login Failed
            }
            catch (IndexOutOfRangeException)
            {
                return false; //login Failed
            }
        }
    }
}
