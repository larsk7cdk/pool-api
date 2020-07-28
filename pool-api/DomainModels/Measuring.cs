using System;

namespace pool_api.DomainModels
{
    public class Measuring
    {
        public Guid Id { get; set; }
        public decimal Temperature { get; set; }
        public decimal Ph { get; set; }
        public DateTime LogDateTime { get; set; }
    }
}