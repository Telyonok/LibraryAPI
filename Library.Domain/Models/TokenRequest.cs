﻿namespace Library.Domain.Models
{
    public class TokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}