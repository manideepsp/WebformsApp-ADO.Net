using DTO;

namespace BLL
{
    /// <summary>
    /// The login.
    /// </summary>
    internal class Login : ILogin
    {
        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool LoginUser(User user)
        {
            DAL.DALFactory factoryObject = new DAL.DALFactory();
            DAL.ILogin login = factoryObject.GetLogin();

            return login.IsLoginSuccess(user);
        }
    }
}
