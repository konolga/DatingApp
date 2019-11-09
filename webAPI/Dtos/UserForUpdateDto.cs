//DTO = data transfer objects defines how the data will be sent over the network
using System;
using System.Collections.Generic;


namespace DatingApp.API.Dtos
{
    public class UserForUpdateDto
    {
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}