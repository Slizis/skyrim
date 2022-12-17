﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}