namespace BLL
{
    /// <summary>
    /// An i otp details interface.
    /// </summary>
    internal interface IOtpDetails
    {
        /// <summary>
        /// Get otp.
        /// </summary>
        /// <returns>A string.</returns>
        string GetOtp(string mailId);
    }
}
