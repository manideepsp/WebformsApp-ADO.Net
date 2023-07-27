namespace BLL
{
    public class BLLFactory
    {
        public IPassword GetPassword()
        {
            IPassword obj = new Password();
            return obj;
        }
        public ILogin GetLogin()
        {
            ILogin obj = new Login();
            return obj;
        }
        public IRegister GetRegister()
        {
            IRegister obj = new Register();
            return obj;
        }
        public IDetails GetEmailDetails()
        {
            IDetails obj = new EmailDetails();
            return obj;
        }
        public IDetails GetOtpDetails()
        {
            IDetails obj = new OtpDetails();
            return obj;
        }
        public IMail GetMail()
        {
            IMail obj = new Mail();
            return obj;
        }
    }
}
