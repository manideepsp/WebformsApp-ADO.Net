using DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    /// <inheritdoc/>
    /// <seealso cref="DAL.IPassword"/>
    public class Password : IPassword
    {
        /// <summary>
        /// Changes a password in db.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        internal bool ChangePasswordInDB(User user)
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
