using AmazonSESFor.NET.Example.Models;

namespace AmazonSESFor.NET.Example.Services
{
    public interface IMailService
    {
        Task<string> SendEmailAsync(MailRequestModel model);
    }
}
