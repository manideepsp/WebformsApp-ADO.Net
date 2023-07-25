using DTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Text;

namespace Backend
{
    /// <summary>
    /// The register.
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
            SqlDataAdapter da = new SqlDataAdapter(SqlQueries.selectAllLoginDetails, SqlQueries.constring);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            if (IsExist(user, dt))
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
        /// Verify password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <returns>A bool.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password by comparing the hashed version with the user's input
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return isPasswordValid;
        }


        /// <summary>
        /// Is exist.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="dt">The dt.</param>
        /// <returns>A bool.</returns>
        private bool IsExist(User user, DataTable dt)
        {
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["UserName"]);
                if (dr["UserName"].ToString() == user.UserName)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                return true; //user found
            }
            else
            {
                return false; //user not found
            }
        }
    }
}
