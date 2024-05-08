using Microsoft.AspNetCore.Mvc;
using RailswareMailtrap.Application.Interfaces;
using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Application.Models.Response;
using RailswareMailtrap.Infrastructure.Helper.ExceptionHandler;

namespace RailswareMailtrap.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/MailSender")]
    public class MailSenderController : ControllerBase
    {
        private readonly IEmailService _mailtrapEmailSender;

        public MailSenderController(IEmailService mailtrapEmailSender)
        {
            _mailtrapEmailSender = mailtrapEmailSender;
        }

        [HttpPost()]
        [Route("sendMail")]
        public async Task<SendMailResponse> Send([FromHeader] string token, [FromForm] MailSendRequest request)
        {
            MailSendRequestValidator validator = new MailSendRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Validation failed: " + string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var response = await _mailtrapEmailSender.SendAsync(token, request);
           return response;
        }
    }
}
