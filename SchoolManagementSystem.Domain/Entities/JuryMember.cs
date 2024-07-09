﻿using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class JuryMember : Base
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? YearOfExperience { get; set; }
        public string? LatestDiploma { get; set; }
        public string? MyProperty { get; set; }
    }
}
