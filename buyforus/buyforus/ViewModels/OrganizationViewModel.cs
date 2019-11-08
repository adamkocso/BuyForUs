using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace buyforus.ViewModels
{
    public class OrganizationViewModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]
        [Display(Name = "Email")]
        public string Email { get; set; }

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

        [Required(ErrorMessage = "The Company Name field is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "The Tax Number field is required.")]
        public string TaxNumber { get; set; }

        public string Headquarters { get; set; }
        public string Description { get; set; }
        public string RepresentativeName { get; set; }
        public string Website { get; set; }

        [Required(ErrorMessage = "The Charity Type field is required.")]
        public string CharityType { get; set; }
        public IFormFile File { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}