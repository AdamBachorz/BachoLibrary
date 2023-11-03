namespace BachorzLibrary.Common.Tools.Email
{
    public class EmailSenderSettings
    {
        public string SmtpClientUrl { get; set; } = "smtp.poczta.onet.pl";
        public string SenderEmail { get; set; } = "adar_1@op.pl";
        public string SenderHeader { get; set; }
        public string SenderValues { get; set; }
    }
}
