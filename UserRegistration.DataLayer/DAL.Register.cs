using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    /// <summary>
    /// The dll register.
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool RegisterUser(User user)
        {
            SqlDataAdapter da = new SqlDataAdapter(SqlQueries.SelectAllLoginDetails, SqlQueries.Constring);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            if (IsUserExist(user, dt))
            {
                return false; // Failed to register, user already exist
            }
            else
            {
                // Hashed password is converted into byte array and stored into the database
                byte[] hashedPasswordBytes = Encoding.UTF8.GetBytes(BCryptHash.HashPassword(user.Password));

                // Create neew datarow and update it to the database
                DataRow newRow = dt.NewRow();
                newRow["UserName"] = user.UserName;
                newRow["Password"] = hashedPasswordBytes;
                newRow["FirstName"] = user.FirstName;
                newRow["LastName"] = user.LastName;
                newRow["EMAIL"] = user.Email;
                dt.Rows.Add(newRow);
                da.Update(dt);
                return true;
            }
        }
        /// <summary>
        /// Is exist.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="dt">The dt.</param>
        /// <returns>A bool.</returns>
        private bool IsUserExist(User user, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserName"].ToString() == user.UserName)
                {
                    return true; //user found
                }
            }
            return false; //user not found
        }
    }
}
