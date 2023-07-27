namespace BLL
{
    /// <summary>
    /// An i details interface.
    /// </summary>
    public interface IDetails
    {
        /// <summary>
        /// Get details.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="kind">The kind.</param>
        /// <returns>A string.</returns>
        string GetDetails(string username, string kind);
    }
}
