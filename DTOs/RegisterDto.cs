using System.ComponentModel.DataAnnotations;
namespace HRManagementSystem.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string email { get; set; }= string.Empty;
        [Required]
        public string password { get; set; }= string.Empty;
    }
}
