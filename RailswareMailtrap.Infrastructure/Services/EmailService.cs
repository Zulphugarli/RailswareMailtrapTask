using AutoMapper;
using Microsoft.Extensions.Configuration;
using RailswareMailtrap.Application.Interfaces;
using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Application.Models.Response;
using RailswareMailtrap.Infrastructure.Helper;
using System.Text.Json;

namespace RailswareMailtrap.Infrastructure.Services
{
    public class EmailService( IMapper mapper, IConfiguration configuration) : IEmailService
    {
        public async Task<SendMailResponse> SendAsync(string token, MailSendRequest request)
        {        
            var mailTrapRequest = new SendRequest
            {
                MailParams = new MailParams
                {
                    From = new Sender { Name = request.SenderName, Email = request.SenderEmail },
                    To = [new Recipient { Name = request.RecipientName, Email = request.RecipientEmail }],
                    Subject = request.Subject,
                    Text = request.Text,
                    Html = string.IsNullOrEmpty(request.Text) ? request.Html : null,
                    Attachments = mapper.Map<Attachment[]>(request.Attachments)
                },
                Settings = new Settings
                {
                    Token = token,
                    Url = $"{configuration["MailTrap:SendBaseUrl"]}/send"
                }
            };
            // set content
            var jsonRequest = JsonSerializer.Serialize(mailTrapRequest.MailParams);
            var response = await HttpClientHelper.PostAsync<SendMailResponse>(mailTrapRequest.Settings.Url, jsonRequest, mailTrapRequest.Settings.Token);         
            return response;
        }
    }
}
