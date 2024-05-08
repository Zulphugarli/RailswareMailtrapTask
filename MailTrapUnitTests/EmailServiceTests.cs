using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Application.Models.Response;
using RailswareMailtrap.Infrastructure.Helper.ExceptionHandler;
using RailswareMailtrap.Infrastructure.Services;
using System.Net;
using System.Text;

namespace MailTrapUnitTests
{
    public class EmailServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConfiguration> _mockConfig;
        private EmailService _emailService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly Mock<IValidator<MailSendRequest>> _mockValidator;
        private readonly MailSendRequestValidator _validator;

        public EmailServiceTests()
        {
            _validator = new MailSendRequestValidator();

            _mockMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _emailService = new EmailService(_mockMapper.Object, _mockConfig.Object);
            _mockValidator = new Mock<IValidator<MailSendRequest>>();

            // Setup Configuration Mock
            _mockConfig.Setup(c => c["MailTrap:SendBaseUrl"]).Returns("https://send.api.mailtrap.io/api");

            // Mocking the HttpClient SendAsync method
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<System.Threading.CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("", Encoding.UTF8, "application/json")
                });
        }


        [Fact]
        public async Task SendAsync_ShouldReturnValidResponse_WhenCalledWithValidParams()
        {
            // Arrange
            string token = "704bcb7f84ef20965503b20ab8657ca8";
            var request = new MailSendRequest
            {
                SenderName = "Sender",
                SenderEmail = "mailtrap@demomailtrap.com",
                RecipientName = "Receipient",
                RecipientEmail = "mailtraptestmail@gmail.com",
                Subject = "Test Subject",
                Text = "Hello, World!",
                Attachments = null // Assuming attachments is nullable and optional
            };

            var expectedUrl = "https://send.api.mailtrap.io/api/send";
            _mockConfig.Setup(c => c["MailTrap:SendBaseUrl"]).Returns("https://send.api.mailtrap.io/api");

            var expectedResponse = new SendMailResponse { Success = true };
            var httpResponse = JsonConvert.SerializeObject(expectedResponse);

            // Act
            var result = await _emailService.SendAsync(token, request);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task SendAsync_ThrowsUnauthorizedException()
        {
            // Arrange
            string token = "invalid_token";
            var request = new MailSendRequest
            {
                SenderName = "Sender",
                SenderEmail = "sender@example.com",
                RecipientName = "Recipient",
                RecipientEmail = "recipient@example.com",
                Subject = "Test Subject",
                Text = "Hello, World!"
            };

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedException>(async () => await _emailService.SendAsync(token, request));
        }

        [Fact]
        public void Validator_Should_Fail_When_SenderEmail_Is_Invalid()
        {
            // Arrange
            var request = new MailSendRequest
            {
                SenderEmail = "bademail",
                SenderName = "Sender",
                RecipientEmail = "recipient@example.com",
                RecipientName = "Recipien",
                Subject = "Hello",
                Text = "This is a test."
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "SenderEmail" && e.ErrorMessage.Contains("not a valid email address"));
        }

    }
}

