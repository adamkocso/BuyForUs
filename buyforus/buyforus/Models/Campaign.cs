using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Models
{
    public class Campaign
    {
        public long CampaignId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
