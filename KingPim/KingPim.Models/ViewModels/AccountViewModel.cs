﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Models.ViewModels
{
    public class AccountViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required]
        public string ConfirmPassword { get; set; }       
        public string Roles { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        
    }
}
