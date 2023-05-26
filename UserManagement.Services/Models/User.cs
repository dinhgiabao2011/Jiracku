namespace UserManagement.Services.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Salt { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set;}
        public string? RefreshToken { get; set; }
        public string? Role { get; set; }
        public int? RoomId { get; set; }
    }
}
