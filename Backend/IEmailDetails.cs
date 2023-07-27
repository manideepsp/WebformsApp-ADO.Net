

namespace BLL
{
    /// <summary>
    /// An i email details interface.
    /// </summary>
    internal interface IEmailDetails
    {
        /// <summary>
        /// Get email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        string GetEmail(string username);

        /// <summary>
        /// Gets a masked email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A string.</returns>
        string GetMaskedEmail(string username);
    }
}
