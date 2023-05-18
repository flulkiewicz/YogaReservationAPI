using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using YogaReservationAPI.Data;
using YogaReservationAPI.Settings;

namespace YogaReservationAPI.Services.InstructorService
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;
        private readonly MailSettings _mailSettings;

        public NotificationService(DataContext context, IOptions<MailSettings> mailSettings)
        {
            _context = context;
            _mailSettings = mailSettings.Value;
        }

        private async Task SendNotification(MailRequest mailRequest)
        {
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }


        public Task<ServiceResponse<string>> SendNotificationToAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> SendNotificationToGroup(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> SendNotificationToUser(int id)
        {
            var response = new ServiceResponse<string>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var mailRequest = new MailRequest();

            mailRequest.ToEmail = user.Email;
            mailRequest.Subject = "Test";
            mailRequest.Body = "Test";

            await SendNotification(mailRequest);

            response.Message = "Email has been sent.";

            return response;
        }
    }
}
