namespace TimeSeriesWebDemo.Models
{

    public class DemoTimeSeries
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public decimal[] Values { get; set; }
    }
}