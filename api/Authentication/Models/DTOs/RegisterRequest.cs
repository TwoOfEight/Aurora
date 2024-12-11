namespace api.Authentication.Models.DTOs
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public User MapToUser()
        {
            User newUser = new();
            newUser.UserName = UserName;
            newUser.Name = Name;
            newUser.Email = Email;
            return newUser;
        }
    }
}