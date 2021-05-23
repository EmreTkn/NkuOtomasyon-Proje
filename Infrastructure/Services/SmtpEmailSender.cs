using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class SmtpEmailSender:IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _username;
        private string _password;

        public SmtpEmailSender(string host, int port, bool enableSsl, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSsl;
            _username = username;
            _password = password;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var client = new SmtpClient(this._host, this._port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true

            };

            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true,

                }
            );
        }
    }
}
