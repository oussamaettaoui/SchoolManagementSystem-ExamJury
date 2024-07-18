using SchoolManagementSystem.Domain.Dtos.EmailDtos;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IEmailService
    {
        void SendEmailAsync(EmailDto emailDto);
    }
}
