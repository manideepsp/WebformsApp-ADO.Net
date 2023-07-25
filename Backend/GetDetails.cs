using DTO;
using System;
using System.Data.SqlClient;
using System.Data;


namespace Backend
{
    /// <summary>
    /// The get details.
    /// </summary>
    public class GetDetails
    {
        /// <summary>
        /// Gets a masked email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public static string GetMaskedEmail(string username)
        {
            string email = GetEmail(username);
            return email == null ? null : MaskEmail(email);
        }

        /// <summary>
        /// Get email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public static string GetEmail(string username)
        {
            SqlDataAdapter da = new SqlDataAdapter(SqlQueries.selectAllLoginDetails, SqlQueries.constring);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

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
        /// Mask email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A string.</returns>
        private static string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return string.Empty; // Return an empty string if the input is null or empty
            }

            // Split the email into username and domain parts using the '@' symbol
            string[] parts = email.Split('@');

            if (parts.Length != 2)
            {
                // Invalid email format; return the original email without masking
                return email;
            }

            string username = parts[0];
            string domain = parts[1];

            // Mask the characters of the username, showing only the first character and replacing the rest with asterisks
            int charactersToMask = Math.Max(username.Length - 1, 1); // Ensure at least one character remains visible
            string maskedUsername = username[0] + new string('*', charactersToMask);

            // Combine the masked username and domain to form the masked email
            string maskedEmail = maskedUsername + "@" + domain;

            return maskedEmail;
        }
    }
}
