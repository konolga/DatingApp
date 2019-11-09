//DTO = data transfer objects defines how the data will be sent over the network
using System.ComponentModel.DataAnnotations;

namespace webAPI.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}