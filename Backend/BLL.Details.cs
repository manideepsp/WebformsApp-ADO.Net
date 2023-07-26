using System;
using DAL;


namespace BLL
{
    /// <summary>
    /// The get details.
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Gets a masked email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public static string GetMaskedEmail(string username)
        {
            DAL.Details obj = new DAL.Details();
            string email = obj.GetEmail(username);
            return email == null ? null : MaskEmail(email);
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
       
        /// <summary>
        /// Get otp.
        /// </summary>
        /// <param name="mailId">The mail id.</param>
        /// <returns>A string.</returns>
        public static string GetOtp(string mailId)
        {
            DAL.Details obj = new DAL.Details();
            return obj.GetOtp(mailId);
        }

        public static string GetEmail(string username)
        {
            DAL.Details obj = new DAL.Details();
            return obj.GetEmail(username);
        }
    }
}
