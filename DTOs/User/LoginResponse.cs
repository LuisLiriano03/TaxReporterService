namespace TaxReporter.DTOs.User
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? RolDescription { get; set; }
        public string? Token { get; set; }

    }

}
