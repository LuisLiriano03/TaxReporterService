namespace TaxReporter.DTOs.User
{
    public class GetUser
    {
        public int UserId { get; set; }
        public string? IdentificationCard { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RolId { get; set; }
        public string? RolDescription { get; set; }
        public string? JobTitle { get; set; }
        public int? IsActive { get; set; }

    }

}
