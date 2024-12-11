namespace client.Models
{
    public class AuthResponse
    {
        public string AuthToken { get; set; }
        public UserDTO User { get; set; }
    }
}
