using System;

namespace pool_api.DomainModels
{
    public class Measure
    {
        public Guid Id { get; set; }
        public decimal Temperature { get; set; }
        public decimal Ph { get; set; }
        public DateTime Timestamp { get; set; }
    }
}