namespace DAL
{
    /// <summary>
    /// An i details interface.
    /// </summary>
    public interface IDetails
    {
        string GetEmail(string username);
        string GetOtp(string mailId);
        void AddOtpToDb(string otp, string mailId);
    }
}
