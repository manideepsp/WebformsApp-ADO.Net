using DTO;

namespace BLL
{
    /// <summary>
    /// The register.
    /// </summary>
    internal class Register : IRegister
    {
        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool RegisterUser(User user)
        {
            DAL.DALFactory factoryObject = new DAL.DALFactory();
            DAL.IRegister register = factoryObject.GetRegister();

            return register.RegisterUser(user);
        }
    }
}