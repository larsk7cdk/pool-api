using System;

namespace pool_api.Models
{
    public class MeasureRequest
    {
        public decimal Temperature { get; set; }
        public decimal Ph { get; set; }
        public string Timestamp { get; set; }
    }
}