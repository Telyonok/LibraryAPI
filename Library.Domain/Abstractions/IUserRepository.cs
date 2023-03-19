﻿using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string email);
    }
}
