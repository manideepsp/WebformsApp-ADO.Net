using DTO;


namespace DAL
{
    /// <summary>
    /// An i login interface.
    /// </summary>
    public interface ILogin
    {
        bool IsLoginSuccess(User user);
    }
}
