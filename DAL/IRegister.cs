using DTO;


namespace DAL
{
    /// <summary>
    /// An i register interface.
    /// </summary>
    public interface IRegister
    {
        bool RegisterUser(User user);
    }
}
