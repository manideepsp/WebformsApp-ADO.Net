using DTO;

namespace BLL
{
    /// <summary>
    /// An i login interface.
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        bool LoginUser(User user);
    }
}
