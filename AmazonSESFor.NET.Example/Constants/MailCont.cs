namespace AmazonSESFor.NET.Example.Constants
{
    public static class MailCont
    {
        public static string ResponseMesageSuccess = "Mail successfully sent. Message Id : {0}";
        public const string ResponseMesageError = "Mail sending failed";

        public static string GetResponseMessageSuccess(string messageId)
        {
            return string.Format(ResponseMesageSuccess, messageId);
        }
    }
}
