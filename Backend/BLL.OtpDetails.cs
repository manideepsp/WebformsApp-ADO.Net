namespace BLL
{
    /// <inheritdoc/>
    /// <seealso cref="BLL.IOtpDetails"/>
    internal class OtpDetails : IOtpDetails, IDetails
    {
        public string GetDetails(string username, string kind)
        {
            if (kind == "otp")
            {
                return GetOtp(username);
            }
            return null;
        }

        /// <summary>
        /// Get otp.
        /// </summary>
        /// <param name="mailId">The mail id.</param>
        /// <returns>A string.</returns>
        public string GetOtp(string mailId)
        {
            DAL.Details obj = new DAL.Details();
            return obj.GetOtp(mailId);
        }
    }
}