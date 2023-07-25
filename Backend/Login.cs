using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    /// <summary>
    /// The login.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool LoginUser(User user)
        {
            return IsLoginSuccess(user);
        }

        /// <summary>
        /// Is login success.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        private bool IsLoginSuccess(User user)
        {
            SqlConnection connection = new SqlConnection(SqlQueries.constring);
            SqlCommand command = new SqlCommand(SqlQueries.selectWithUsername, connection);
            command.Parameters.AddWithValue("UserName", user.UserName);

            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            try
            {
                // Select all rows where UserName is username
                DataRow[] foundRows = dt.Select($"UserName = '{user.UserName}'");
                DataRow dr = foundRows[0];
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
