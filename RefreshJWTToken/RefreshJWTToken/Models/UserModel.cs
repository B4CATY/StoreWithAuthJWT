using System.ComponentModel.DataAnnotations;

namespace RefreshJWTToken.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
