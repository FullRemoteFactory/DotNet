using System.Net.Mail;
using System.Net;

namespace VoyageBack.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string password)
        {
            try
            {
                // SMTP configuration
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "glissinajib@gmail.com";
                //string smtpPassword = "";

                using (var client = new SmtpClient(smtpHost))
                {
                    client.Port = smtpPort;
                    //here in the credential i add Password from google account for security reasons and I allow "Less secure  Account"
                    client.Credentials = new NetworkCredential(smtpUsername, "qzuzjpfeuuryjlon");
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(new MailAddress(toEmail));
                    mailMessage.Subject = "WELCOME TO AlyssVoyage";

                    // Customize the email body with the provided referent name and password
                    mailMessage.Body = $"Welcome to AlyssVoyage! We're thrilled to have you on board.\r\n\r\n" +
                                       $"Here are your login credentials:\r\n\r\n" +
                                       $"Your Email : {toEmail}\r\n" +
                                       $"Password: {password}\r\n\r\n" +
                                       $"Please log in using the link below:\r\n\r\n" +
                                       $"[ www.AlyssVoyage.com.tn]";

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while sending the email: {ex.Message}");
            }
        }
    }
}
