using System;

namespace BLL
{
    /// <inheritdoc/>
    /// <seealso cref="BLL.IEmailDetails"/>
    internal class EmailDetails : IEmailDetails, IDetails
    {
        public string GetDetails(string username, string kind)
        {
            if (kind == "maskedemail")
            {
                return GetMaskedEmail(username);
            }
            if (kind == "email")
            {
                return GetEmail(username);
            }
            else return null;
        }

        /// <summary>
        /// Get email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public string GetEmail(string username)
        {
            DAL.DALFactory factory = new DAL.DALFactory();
            DAL.IDetails details = factory.GetDetails();

            return details.GetEmail(username);
        }

        /// <summary>
        /// Gets a masked email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        public string GetMaskedEmail(string username)
        {
            DAL.DALFactory factoryObject = new DAL.DALFactory();
            DAL.IDetails details = factoryObject.GetDetails();

            string email = details.GetEmail(username);
            return email == null ? null : MaskEmail(email);
        }

        /// <summary>
        /// Mask email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A string.</returns>
        private string MaskEmail(string email)
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
