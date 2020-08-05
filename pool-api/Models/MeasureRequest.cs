namespace pool_api.Models
{
    public class MeasureRequest
    {
        public decimal Temperature { get; set; }
        public ulong EpochTime { get; set; }
    }
}