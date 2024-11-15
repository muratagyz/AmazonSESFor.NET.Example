using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AmazonSESFor.NET.Example.Constants;
using AmazonSESFor.NET.Example.Models;

namespace AmazonSESFor.NET.Example.Services
{
    public class AmazonSESService(IAmazonSimpleEmailService amazonSimpleEmailService, ILogger<AmazonSESService> logger, IConfiguration configuration) : IMailService
    {
        public async Task<string> SendEmailAsync(MailRequestModel model)
        {
            try
            {
                Body mailBody = new(new Content(model.Body));
                Message message = new(new Content(model.Subject), mailBody);
                Destination destination = new([model.To]);

                SendEmailRequest request = new(configuration["MailSettings:From"], destination, message);
                await amazonSimpleEmailService.SendEmailAsync(request);

                return MailCont.SuccessMesageResponse;
            }
            catch (Exception ex)
            {
                logger.LogError("SendEmailAsync failed with exception: " + ex.Message);
                return MailCont.ErrorMesageResponse;
            }
        }
    }
}
