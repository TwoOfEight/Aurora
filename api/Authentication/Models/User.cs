using api.Authentication.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace api.Authentication.Models
{
    public class User
    {
        [EmailAddress]
        public string? Email { get; set; }

        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 7, ErrorMessage = "Name must be between 7 and 100 characters.")]
        public string? Name { get; set; }

        [Required]
        public byte[]? PasswordHash { get; set; }

        [Required]
        public byte[]? PasswordSalt { get; set; }

        public string? Role { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 100 characters.")]
        public string? UserName { get; set; }

        public UserDTO castToDto()
        {
            UserDTO dto = new();
            dto.Id = Id;
            dto.UserName = UserName;
            dto.Name = Name;
            dto.Email = Email;
            return dto;
        }
    }
}