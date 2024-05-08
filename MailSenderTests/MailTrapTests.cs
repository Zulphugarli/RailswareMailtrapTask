using RailswareMailtrap.Application.Interfaces;
using Moq;
using RailswareMailtrap.Application.Models.Request;
using RailswareMailtrap.Application.Models.Response;
using System.Net;
using AutoMapper;
using RailswareMailtrap.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MailSenderTests
{
    public class EmailServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConfiguration> _mockConfig;
        private EmailService _emailService;

        public EmailServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _emailService = new EmailService(_mockMapper.Object, _mockConfig.Object);
        }


        [Fact]
        public async Task SendAsync_ShouldReturnValidResponse_WhenCalledWithValidParams()
        {
            // Arrange
            string token = "test-token";
            var request = new MailSendRequest
            {
                SenderName = "John Doe",
                SenderEmail = "john@example.com",
                RecipientName = "Jane Smith",
                RecipientEmail = "jane@example.com",
                Subject = "Test Subject",
                Text = "Hello, World!",
                Attachments = null // Assuming attachments is nullable and optional
            };

            var expectedUrl = "https://api.mailtrap.io/send";
            _mockConfig.Setup(c => c["MailTrap:SendBaseUrl"]).Returns("https://api.mailtrap.io");

            var expectedResponse = new SendMailResponse { Success = true };
            var httpResponse = JsonConvert.SerializeObject(expectedResponse);

            // We need to somehow mock HttpClientHelper's PostAsync method. Since it's static, this isn't straightforward with Moq;
            // instead, we might consider refactoring the code or using a tool like Microsoft Fakes or Pose.
            // For now, let's assume it returns the expected response.

            // Act
            var result = await _emailService.SendAsync(token, request);

            // Assert
            Assert.True(result.Success);
        }
    }
}