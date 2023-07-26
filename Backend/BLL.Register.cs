using DTO;

namespace BLL
{
    public class Register
    {
        public bool RegisterUser(User user)
        {
            DAL.Register obj = new DAL.Register();
            return obj.RegisterUser(user);
        }
    }
}
