using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    public class Login
    {
        public bool LoginUser(User user)
        {
            return IsLoginSuccess(user);
        }

        private bool IsLoginSuccess(User user)
        {
            SqlConnection connection = new SqlConnection(Sql.constring);
            SqlCommand command = new SqlCommand(Sql.selectWithUsername, connection);
            command.Parameters.AddWithValue("UserName", user.UserName);

            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            try
            {
                DataRow[] foundRows = dt.Select($"UserName = '{user.UserName}'");
                DataRow dr = foundRows[0];
                string dbPassword = Encoding.UTF8.GetString((byte[])dr["Password"]);
                Console.WriteLine(dbPassword);
                if (dr["UserName"].ToString() == user.UserName && BCrypt.Net.BCrypt.Verify(user.Password, dbPassword))
                {
                    return true; //Login successful
                }
                return false; //Login Failed
            }
            catch (System.IndexOutOfRangeException ex)
            {
                return false; //login Failed
            }
        }
    }
}
