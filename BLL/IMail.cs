namespace BLL
{
    /// <summary>
    /// An i mail interface.
    /// </summary>
    public interface IMail
    {
        /// <summary>
        /// Sends an otp mail.
        /// </summary>
        /// <param name="mailId">The mail id.</param>
        /// <returns>A bool.</returns>
        bool SendOtpMail(string mailId);
    }
}
