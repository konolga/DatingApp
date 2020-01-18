//DTO = data transfer objects defines how the data will be sent over the network

using System.ComponentModel.DataAnnotations;

namespace webAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Characters are not allowed")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Characters are not allowed")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Invalid password")]
        [StringLength(16, MinimumLength=8, ErrorMessage="Password must be between 8 and 16 characters")]
        public string Password { get; set; }
    }
}