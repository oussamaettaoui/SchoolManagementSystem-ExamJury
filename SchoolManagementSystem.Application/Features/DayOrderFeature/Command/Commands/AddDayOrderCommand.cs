using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{
    public class AddDayOrderCommand : IRequest<Result>
    {
        public string? DayOrderTitle { get; set; }
        public bool HasTable { get; set; }
        public DocumentType DocType { get; set; }
        public IFormFile? DocumentFile { get; set; }
    }
}
