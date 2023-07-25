namespace Backend
{
    internal class BCryptHash
    {
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
