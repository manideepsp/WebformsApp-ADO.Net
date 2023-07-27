using DTO;

namespace BLL
{
    /// <summary>
    /// An i password interface.
    /// </summary>
    public interface IPassword
    {
        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        bool ChangePassword(User user);
    }
}
