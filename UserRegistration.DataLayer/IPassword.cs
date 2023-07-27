using DTO;

namespace DAL
{
    /// <summary>
    /// An i password interface.
    /// </summary>
    public interface IPassword
    {
        bool ChangePasswordInDB(User user);
    }
}
