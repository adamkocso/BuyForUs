﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace buyforus.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required (ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}