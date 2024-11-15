namespace AmazonSESFor.NET.Example.Models
{
    public class MailRequestModel
    {
        public List<string> ToAddresses { get; set; } = new List<string>();
        public List<string> CcAddresses { get; set; } = new List<string>();
        public List<string> BccAddresses { get; set; } = new List<string>();
        public string? BodyHtml { get; set; }
        public string? BodyText { get; set; }
        public string? Subject { get; set; }
    }
}
