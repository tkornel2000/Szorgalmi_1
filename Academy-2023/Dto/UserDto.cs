using System.ComponentModel.DataAnnotations;

namespace Academy_2023.Data
{
    public class UserDto
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Role { get; set; }
    }
}
