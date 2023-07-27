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
            DAL.DALFactory factory = new DAL.DALFactory();
            DAL.IDetails details = factory.GetDetails();

            return details.GetOtp(mailId);
        }
    }
}