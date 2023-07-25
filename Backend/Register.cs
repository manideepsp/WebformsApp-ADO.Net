using DTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Text;

namespace Backend
{
    public class Register
    {
        public bool RegisterUser(User user)
        {
            SqlDataAdapter da = new SqlDataAdapter(Sql.selectAllLoginDetails, Sql.constring);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            if (IsExist(user, dt))
            {
                return false; // Failed to register, user already exist
            }
            else
            {

                byte[] hashedPasswordBytes = Encoding.UTF8.GetBytes(BCryptHash.HashPassword(user.Password));
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

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password by comparing the hashed version with the user's input
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return isPasswordValid;
        }


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
