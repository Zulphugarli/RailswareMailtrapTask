using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Application.Models.Response;

namespace RailswareMailtrap.Application.Interfaces
{
    public interface IEmailService
    {
        Task<SendMailResponse> SendAsync(string token, MailSendRequest request);
    }
}
