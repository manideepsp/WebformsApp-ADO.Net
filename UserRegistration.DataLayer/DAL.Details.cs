using DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    /// <summary>
    /// The class 1.
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Get email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public string GetEmail(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["Ashish_db"].ConnectionString;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQueries.SelectWithUsername, constr);
            adapter.SelectCommand.Parameters.AddWithValue("UserName", username);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            DataTable dt = new DataTable("users");
            adapter.Fill(dt);

            try
            {
                DataRow[] foundRows = dt.Select($"UserName = '{username}'");

                DataRow dr = foundRows[0];
                return dr["EMAIL"].ToString();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Get otp.
        /// </summary>
        /// <param name="mailId">The mail id.</param>
        /// <returns>A string.</returns>
        public string GetOtp(string mailId)
        {
            string constr = ConfigurationManager.ConnectionStrings["Ashish_db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQueries.SelectWithEmail, connection))
                {

                    adapter.SelectCommand.Parameters.AddWithValue("email", mailId);

                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        return dr["otp"].ToString();
                    }
                    return null;
                }
            }

            /*SqlConnection connection = new SqlConnection(SqlQueries.Constring);
            SqlCommand command = new SqlCommand(SqlQueries.SelectWithEmail, connection);
            command.Parameters.AddWithValue("@email", mailId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //DataRow[] foundRows = dt.Select($"EMAIL = '{mailId}'");

            DataRow dr = dt.Rows[0];
            return dr["otp"].ToString();*/
        }

        /// <summary>
        /// Adds an otp to db.
        /// </summary>
        /// <param name="otp">The otp.</param>
        /// <param name="mailId">The mail id.</param>
        /// <returns></returns>
        public void addOtpToDb(string otp, string mailId)
        {
            string constr = ConfigurationManager.ConnectionStrings["Ashish_db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQueries.SelectWithEmail, connection))
                {

                    adapter.SelectCommand.Parameters.AddWithValue("email", mailId);

                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        dr["otp"] = otp;
                        adapter.Update(dt);
                    }
                    //return false;
                }
            }

        }

        /*
         * SqlConnection connection = new SqlConnection(SqlQueries.Constring);
            SqlCommand command = new SqlCommand(SqlQueries.SelectWithEmail, connection);
            command.Parameters.AddWithValue("@email", mailId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DataRow dr = dt.Rows[0];
            dr["otp"] = otp;
            dr.AcceptChanges();
            dt.AcceptChanges();
            adapter.Update(dt);
        */
        /// <summary>
        /// Changes a password in db.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool ChangePasswordInDB(User user)
        {
            string constr = ConfigurationManager.ConnectionStrings["Ashish_db"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQueries.SelectWithUsername, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("UserName", user.UserName);

                        SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 1)
                        {
                            DataRow dr = dt.Rows[0];
                            dr["Password"] = Encoding.UTF8.GetBytes(BCryptHash.HashPassword(user.Password));
                            adapter.Update(dt);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
