using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using buyforus.Models;

namespace buyforus.ViewModels
{
    public class AddCampaignViewModel
    {
        [Required(ErrorMessage = "Campaign title need to be set!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description need to be set!")]
        public string Description { get; set; }
    }
}