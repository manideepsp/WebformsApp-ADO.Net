using DTO;

namespace BLL
{
    /// <summary>
    /// The change parameter.
    /// </summary>
    internal class Password : IPassword
    {
        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool ChangePassword(User user)
        {
            DAL.Details dLLDetails = new DAL.Details();
            if (dLLDetails.ChangePasswordInDB(user))
            {
                return true;
            }
            return false;
        }
    }
}
