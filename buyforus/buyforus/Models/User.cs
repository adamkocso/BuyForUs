using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Models
{
    public class User : IdentityUser
    {
        public string Uri { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string TaxNumber { get; set; }
        public string Headquarters { get; set; }
        public string Description { get; set; }
        public string CharityType { get; set; }
        public string Website { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }
}