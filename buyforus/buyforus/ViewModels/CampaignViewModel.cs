using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace buyforus.ViewModels
{
    public class CampaignViewModel
    {
        public Campaign Campaign { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
