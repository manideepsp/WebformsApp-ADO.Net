using DTO;
using System;
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
            SqlDataAdapter da = new SqlDataAdapter(SqlQueries.SelectAllLoginDetails, SqlQueries.Constring);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            try
            {
                //DataRow[] foundRows = dt.Select($"UserName = '{username}'");

                DataRow dr = dt.Rows[0];
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
            SqlConnection connection = new SqlConnection(SqlQueries.Constring);
            SqlCommand command = new SqlCommand(SqlQueries.SelectWithEmail, connection);
            command.Parameters.AddWithValue("@email", mailId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //DataRow[] foundRows = dt.Select($"EMAIL = '{mailId}'");

            DataRow dr = dt.Rows[0];
            return dr["otp"].ToString();
        }

        /// <summary>
        /// Adds an otp to db.
        /// </summary>
        /// <param name="otp">The otp.</param>
        /// <param name="mailId">The mail id.</param>
        /// <returns></returns>
        public void addOtpToDb(string otp, string mailId)
        {
            SqlConnection connection = new SqlConnection(SqlQueries.Constring);
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
        }

        /// <summary>
        /// Changes a password in db.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool ChangePasswordInDB(User user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(SqlQueries.Constring);
                SqlCommand command = new SqlCommand(SqlQueries.SelectWithUsername, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //DataRow[] foundRows = dt.Select($"UserName = '{user.UserName}'");
                DataRow dr = dt.Rows[0];
                dr["Password"] = Encoding.UTF8.GetBytes(BCryptHash.HashPassword(user.Password));
                dr.AcceptChanges();
                dt.AcceptChanges();
                adapter.Update(dt);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
