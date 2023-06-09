﻿// Disabled CS8618 because the 'User' class is used by EntityFramework.
#pragma warning disable CS8618


namespace Library.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
