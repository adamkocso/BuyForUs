using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.ViewModels
{
    public class CampaignViewModel
    {
        public Campaign Campaign { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}
