using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ChangeParameter
    {
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

        private bool ChangePasswordInDB(User user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Sql.constring);
                SqlCommand command = new SqlCommand(Sql.selectWithUsername, connection);
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
