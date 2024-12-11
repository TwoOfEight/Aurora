namespace api.Authentication.Models.DTOs
{
    public class AuthResponse
    {
        public string AuthToken { get; set; }
        public UserDTO User { get; set; }
    }
}