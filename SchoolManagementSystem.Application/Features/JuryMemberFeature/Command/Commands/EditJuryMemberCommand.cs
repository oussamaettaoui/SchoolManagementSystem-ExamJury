﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands
{
    public class EditJuryMemberCommand : IRequest<string>
    {
        public  Guid JuryMemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public int YearOfExperience { get; set; }
        public string? LatestDiploma { get; set; }
        public int Role { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
}
