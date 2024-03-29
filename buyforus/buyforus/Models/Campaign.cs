﻿using System;
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
        public DateTime ExpiryDate { get; set; }
        public int TotalPrice { get; set; }
        public List<Product> Products { get; set; }
        public string UserId { get; set; }
        public string Uri { get; set; }
    }
}