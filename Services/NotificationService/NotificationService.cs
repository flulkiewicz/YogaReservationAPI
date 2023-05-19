using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.NotificationsDtos;
using YogaReservationAPI.Models;
using YogaReservationAPI.Settings;

namespace YogaReservationAPI.Services.InstructorService
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly MailSettings _mailSettings;

        public NotificationService(DataContext context, IOptions<MailSettings> mailSettings, IMapper mapper)
        {
            _context = context;
            _mailSettings = mailSettings.Value;
            _mapper = mapper;

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

        private async Task<ServiceResponse<List<string>>> SendNotificationToGroup(MailRequest mailRequest, List<User> users)
        {
            var response = new ServiceResponse<List<string>>();
            var result = new List<string>();
            int successfulNotifications = 0;

            foreach (var user in users)
            {
                if (user.Email == null || !IsMailValid(user.Email))
                {
                    result.Add($"Failed- User id:{user.Id} have incorrect or empty e-mail");
                    continue;
                }

                mailRequest.ToEmail = user.Email;

                await SendNotification(mailRequest);
                result.Add($"Success- User id:{user.Id}, email:{user.Email}");
                successfulNotifications++;
            }

            response.Data = result;
            response.Message = $"{successfulNotifications}/{users.Count} emails has been sent succesfully.";

            return response;
        }

        private bool IsMailValid(string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
        }


        public async Task<ServiceResponse<List<string>>> SendNotificationToAll(EmailDto emailDto)
        {
            var users = await _context.Users.ToListAsync();

            if (users.Count == 0)
                throw new NotFoundException("No users in database");

            var mailRequest = _mapper.Map<MailRequest>(emailDto);

            var response = await SendNotificationToGroup(mailRequest, users);

            return response;
        }

        public async Task<ServiceResponse<List<string>>> SendNotificationToYogaTrainingParticipants(int trainingId, EmailDto emailDto)
        {
            var yogaTraining = await _context.YogaTrainings
                .Include(y => y.Participants)
                .FirstOrDefaultAsync(y => y.Id == trainingId);


            if (yogaTraining == null)
                throw new NotFoundException("Yoga training with given id has not been found");

            var users = yogaTraining.Participants;

            if (users.Count == 0)
                throw new NotFoundException("Yoga training do not have any users on list");

            var mailRequest = _mapper.Map<MailRequest>(emailDto);


            var response = new ServiceResponse<List<string>>();
            var result = new List<string>();
            int successfulNotifications = 0;

            foreach (var user in users)
            {
                if (user.Email == null || !IsMailValid(user.Email))
                {
                    result.Add($"Failed- User id:{user.Id} have incorrect or empty e-mail");
                    continue;
                }

                mailRequest.ToEmail = user.Email;

                await SendNotification(mailRequest);
                result.Add($"Success- User id:{user.Id}, email:{user.Email}");
                successfulNotifications++;
            }

            response.Data = result;
            response.Message = $"{successfulNotifications}/{users.Count} emails has been sent succesfully.";

            return response;
        }

        public async Task<ServiceResponse<string>> SendNotificationToUser(int userId, EmailDto emailDto)
        {
            var response = new ServiceResponse<string>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.Email == null)
                throw new NotFoundException("User or users mail is null.");

            var mailRequest = _mapper.Map<MailRequest>(emailDto);
            mailRequest.ToEmail = user.Email;

            await SendNotification(mailRequest);

            response.Message = "Email has been sent.";

            return response;
        }
    }
}
