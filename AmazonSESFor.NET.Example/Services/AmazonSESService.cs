using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AmazonSESFor.NET.Example.Constants;
using AmazonSESFor.NET.Example.Models;

namespace AmazonSESFor.NET.Example.Services;

public class AmazonSESService(AmazonSimpleEmailServiceClient amazonSimpleEmailService, ILogger<AmazonSESService> logger, IConfiguration configuration) : IMailService
{
    public async Task<string> SendEmailAsync(MailRequestModel model)
    {
        try
        {
            var requestModel = new SendEmailRequest
            {
                Destination = new Destination
                {
                    BccAddresses = model.BccAddresses,
                    CcAddresses = model.CcAddresses,
                    ToAddresses = model.ToAddresses
                },
                Message = new Message
                {
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Data = model.BodyHtml
                        },
                        Text = new Content
                        {
                            Data = model.BodyText
                        }
                    },
                    Subject = new Content
                    {
                        Data = model.Subject
                    }
                },
                Source = configuration["AwsMailSettings:From"]
            };

            var response = await amazonSimpleEmailService.SendEmailAsync(requestModel);

            var responseMessage = MailCont.GetResponseMessageSuccess(response.MessageId);

            return responseMessage;
        }
        catch (Exception ex)
        {
            logger.LogError("SendEmailAsync failed with exception: " + ex.Message);
            return MailCont.ResponseMesageError;
        }
    }
}
