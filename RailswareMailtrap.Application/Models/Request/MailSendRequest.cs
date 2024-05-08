using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace RailswareMailtrap.Application.Models.Request
{
    public class MailSendRequest
    {
        public string? SenderEmail { get; set; }
        public string? SenderName { get; set; }
        public string? RecipientEmail { get; set; }
        public string? RecipientName { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public string? Html { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
    public class MailSendRequestValidator : AbstractValidator<MailSendRequest>
    {
        public MailSendRequestValidator()
        {
            // Validate the Sender's Email
            RuleFor(x => x.SenderEmail)
                .NotEmpty().WithMessage("Sender's email is required.")
                .EmailAddress().WithMessage("Sender's email is not a valid email address.");

            // Validate the Sender's Name
            RuleFor(x => x.SenderName)
                .NotEmpty().WithMessage("Sender's name is required.")
                .MaximumLength(50).WithMessage("Sender's name must be less than 50 characters.");

            // Validate the Recipient's Email
            RuleFor(x => x.RecipientEmail)
                .NotEmpty().WithMessage("Recipient's email is required.")
                .EmailAddress().WithMessage("Recipient's email is not a valid email address.");

            // Validate the Recipient's Name
            RuleFor(x => x.RecipientName)
                .NotEmpty().WithMessage("Recipient's name is required.")
                .MaximumLength(50).WithMessage("Recipient's name must be less than 50 characters.");

            // Validate the Subject
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Email subject is required.")
                .MaximumLength(100).WithMessage("Subject must be less than 100 characters.");
        }
    }
}
