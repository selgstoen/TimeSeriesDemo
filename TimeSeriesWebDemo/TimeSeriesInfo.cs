using Statkraft.XTimeSeries;

namespace TimeSeriesWebDemo
{
    public class TimeSeriesInfo
    {
        public TimeSeriesInfo()
        { }

        public TimeSeriesInfo(string id, SourceSystem sourceSystem)
        {
            Id = id;
            SourceSystem = sourceSystem;
        }
        public string Id { get; set; }


        public SourceSystem SourceSystem { get; set; }
    }
}