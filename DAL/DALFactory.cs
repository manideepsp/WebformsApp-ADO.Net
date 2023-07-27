namespace DAL
{
    /// <summary>
    /// The dal factory.
    /// </summary>
    public class DALFactory
    {
        public IDetails GetDetails()
        {
            IDetails details = new Details();
            return details;
        }
        public ILogin GetLogin()
        {
            ILogin login = new Login();
            return login;
        }
        public IPassword GetPassword()
        {
            IPassword password = new Password();
            return password;
        }
        public IRegister GetRegister()
        {
            IRegister register = new Register();
            return register;
        }
    }
}
