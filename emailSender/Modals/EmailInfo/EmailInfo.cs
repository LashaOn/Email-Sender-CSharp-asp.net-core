namespace emailSender.Modals.EmailInfo
{
    public class EmailInfo : EmailInfoViewModel
    {

        public EmailInfo(string senderName, string title, string senderEmail, string senderPass, string emailThem, string host, int port, bool ssl)
        {
            SenderName = senderName;
            Title = title;
            SenderEmail = senderEmail;
            SenderPass = senderPass;
            EmailThem = emailThem;
            Host = host;
            Port = port;
            Ssl = ssl;
        }
    }

}

