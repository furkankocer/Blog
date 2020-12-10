﻿using System;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public string Username { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public Role Role { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
