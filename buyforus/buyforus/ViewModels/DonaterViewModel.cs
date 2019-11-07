﻿using System.ComponentModel.DataAnnotations;

namespace buyforus.ViewModels
{
    public class DonaterViewModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}