﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommationDemo
{
    public class LoginDTO
    {
        public LoginDTO(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}
