﻿namespace TaxReporter.DTOs.User
{
    public class GetUser
    {
        public int UserId { get; set; }
        public int? NumberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public int? RolId { get; set; }
        public string? RolDescription { get; set; }
        public string? JobTitle { get; set; }
        public int? IsActive { get; set; }

    }

}