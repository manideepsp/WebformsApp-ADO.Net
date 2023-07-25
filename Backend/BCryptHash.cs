namespace Backend
{
    /// <summary>
    /// The b crypt hash.
    /// </summary>
    internal class BCryptHash
    {
        /// <summary>
        /// Hash password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>A string.</returns>
        internal static string HashPassword(string password)
        {
            // Generate a random salt with 10 rounds (recommended minimum rounds for bcrypt)
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);

            // Hash the password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }
    }
}
