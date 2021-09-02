namespace emailSender.Modals.EmailInfo
{
    public class EmailInfoViewModel
    {
        public string SenderName { get; set; }

        public string Title { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPass { get; set; }

        public string EmailThem { get; set; }

        public string Host { get; set; } = "185.88.152.25";

        public int Port { get; set; } = 25;

        public bool Ssl { get; set; }
    }
}
