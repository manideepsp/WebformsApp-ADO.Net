using DTO;

namespace BLL
{
    /// <summary>
    /// An i register interface.
    /// </summary>
    public interface IRegister
    {
        bool RegisterUser(User user);
    }
}
