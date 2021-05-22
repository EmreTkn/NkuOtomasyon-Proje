using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string SchoolNumber { get; set; }
        public string Token { get; set; }
        public Types Type { get; set; }
     
    }
}
