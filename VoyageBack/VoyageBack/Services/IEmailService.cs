namespace VoyageBack.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string password);
    }
}
