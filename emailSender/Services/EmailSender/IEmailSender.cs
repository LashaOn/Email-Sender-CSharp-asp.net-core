using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace emailSender.Services.EmailSender
{
    public interface IEmailSender
    { 
        
        Task SendEmail(string senderName, string senderEmail, string senderPass, string title, string emailThem, string host, int port, bool ssl, string userName, string userEmail);
      
    }
}
