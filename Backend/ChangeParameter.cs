using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    /// <summary>
    /// The change parameter.
    /// </summary>
    public class ChangeParameter
    {
        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool ChangePassword(User user)
        {
            if (ChangePasswordInDB(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Changes a password in db.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        private bool ChangePasswordInDB(User user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(SqlQueries.constring);
                SqlCommand command = new SqlCommand(SqlQueries.selectWithUsername, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataRow[] foundRows = dt.Select($"UserName = '{user.UserName}'");
                DataRow dr = foundRows[0];
                dr["Password"] = Encoding.UTF8.GetBytes(BCryptHash.HashPassword(user.Password));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
