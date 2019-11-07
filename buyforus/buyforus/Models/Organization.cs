using System.Collections.Generic;

namespace buyforus.Models
{
    public class Organization : User
    {
        public List<Campaign> Campaigns { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string TaxNumber { get; set; }
        public string Headquarters { get; set; }
        public string Description { get; set; }
        public string CharityType { get; set; }
    }
}