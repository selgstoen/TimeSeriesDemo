using System.Collections.Generic;
using System.Web.Http;
using TimeSeriesWebDemo.Models;

namespace TimeSeriesWebDemo.Controllers
{
    public class DemoTimeSeriesController : ApiController
    {

        // GET: api/DemoTimeSeries
        public IEnumerable<DemoTimeSeries> GetDemoTimeSeries()
        {
            return GetHardCoded();
        }

        private IEnumerable<DemoTimeSeries> GetHardCoded()
        {
            var tsList = new List<DemoTimeSeries> { new DemoTimeSeries { Id = "444", Source = "Brady", Values = new decimal[] { 1, 45, 22 } }, new DemoTimeSeries { Id = "333", Source = "Smg", Values = new decimal[] { 1, 45, 22 } } };

            return tsList;
        }
    }
}