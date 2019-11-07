using System.Collections.Generic;

namespace buyforus.Models
{
    public class Organization : User
    {
        public List<Campaign> Campaigns { get; set; }
    }
}