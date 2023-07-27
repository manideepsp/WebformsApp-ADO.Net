using DTO;
using System;
using System.Net; // ToMail
using System.Net.Mail;

namespace BLL
{
    internal class Mail : IMail
    {
        public bool SendOtpMail(string mailId)
        {
            string otp = RandomNumberGenerator.GenerateRandom6DigitNumber().ToString();
            DAL.Details obj = new DAL.Details();
            obj.addOtpToDb(otp, mailId);
            string subject = "OTP for Login";
            string body = $"Your OTP is: {otp}";

            try
            {
                // Create the email message
                MailMessage mail = new MailMessage(SmtpDetails.FromEmailAddress, mailId, subject, body);

                // Create the SMTP client and set its credentials
                SmtpClient smtpClient = new SmtpClient(SmtpDetails.SmtpServer, SmtpDetails.SmtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SmtpDetails.SmtpUsername, SmtpDetails.SmtpPassword);
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send OTP email: " + ex.Message);
                return false;
            }
        }
    }
}
