using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Statkraft.Time;
using Statkraft.XTimeSeries;
using TimeSeriesWebDemo.Models;

namespace TimeSeriesWebDemo.Controllers
{
    public class DemoTimeSeriesController : ApiController
    {
        private static readonly Calendar CalendarLocal = Calendar.Local;
        private readonly UtcTime _starTime = CalendarLocal.ToUtcTime(2013, 12, 1, 0, 0, 0);
        private readonly UtcTime _endTime = CalendarLocal.ToUtcTime(2013, 12, 2, 0, 0, 0);

        private const string IdOne = "id-one";
        private const string IdTwo = "id-two";

        // GET: api/DemoTimeSeries
        public IEnumerable<DemoTimeSeries> GetDemoTimeSeries()
        {
            var period = new Period(_starTime, _endTime);
            var service = new TimeSeriesService();
            var infos = GetTsInfos();

            var timeSeries = service.GetTimeSeries(infos, period);

            return MapToDemoTimeSeries(timeSeries);

        }

        private IEnumerable<DemoTimeSeries> MapToDemoTimeSeries(IEnumerable<ITimeSeries> timeSeries)
        {
            return
                timeSeries.Select(
                    ts =>
                        new DemoTimeSeries
                        {
                            Id = ts.Info.Name,
                            Source = ts.Info.SourceSystem.ToString(),
                            Values = MapValues(ts).ToArray()
                        });
        }

        private IEnumerable<decimal> MapValues(ITimeSeries ts)
        {
            for (int i = 0; i < ts.Count; i++)
            {
                var val = ts.Value(i);
                if (val.Missing)
                    yield return 0;
                yield return Math.Round((decimal)ts.Value(i).V, 2); 
            }

        }

        private IList<TimeSeriesInfo> GetTsInfos()
        {
            return new List<TimeSeriesInfo>
            {
                new TimeSeriesInfo(IdTwo, SourceSystem.SmG),
                new TimeSeriesInfo(IdOne, SourceSystem.Brady)
            };
        }
    }
}