using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
