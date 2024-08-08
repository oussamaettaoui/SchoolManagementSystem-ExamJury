using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{
    public class EditDayOrderCommand : IRequest<Result>
    {
        public Guid DayOrderId { get; set; }
        public string? DayOrderTitle { get; set; }
        public DocumentType DocType { get; set; }
        public IFormFile? DocumentFile { get; set; }
    }
}
