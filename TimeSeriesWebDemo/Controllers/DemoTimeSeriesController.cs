﻿using System.Collections.Generic;
using System.Web.Http;
using TimeSeriesWebDemo.Models;

namespace TimeSeriesWebDemo.Controllers
{
    public class DemoTimeSeriesController : ApiController
    {
        private TimeSeriesDemoContext db = new TimeSeriesDemoContext();

        // GET: api/DemoTimeSeries
        public IEnumerable<DemoTimeSeries> GetDemoTimeSeries()
        {
            return GetHardCoded();
        }

        private IEnumerable<DemoTimeSeries> GetHardCoded()
        {
            var tsList = new List<DemoTimeSeries> { new DemoTimeSeries { Id = "444", Source = "øl", Values = new double[] { 1, 45, 22 } }, new DemoTimeSeries { Id = "333", Source = "vin", Values = new double[] { 1, 45, 22 } } };

            return tsList;
        }

        //    // GET: api/DemoTimeSeries/5
        //[ResponseType(typeof(DemoTimeSeries))]
        //public async Task<IHttpActionResult> GetDemoTimeSeries(string id)
        //{
        //    DemoTimeSeries demoTimeSeries = await db.DemoTimeSeries.FindAsync(id);
        //    if (demoTimeSeries == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(demoTimeSeries);
        //}

        //// PUT: api/DemoTimeSeries/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutDemoTimeSeries(string id, DemoTimeSeries demoTimeSeries)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != demoTimeSeries.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(demoTimeSeries).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DemoTimeSeriesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/DemoTimeSeries
        //[ResponseType(typeof(DemoTimeSeries))]
        //public async Task<IHttpActionResult> PostDemoTimeSeries(DemoTimeSeries demoTimeSeries)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DemoTimeSeries.Add(demoTimeSeries);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DemoTimeSeriesExists(demoTimeSeries.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = demoTimeSeries.Id }, demoTimeSeries);
        //}

        //// DELETE: api/DemoTimeSeries/5
        //[ResponseType(typeof(DemoTimeSeries))]
        //public async Task<IHttpActionResult> DeleteDemoTimeSeries(string id)
        //{
        //    DemoTimeSeries demoTimeSeries = await db.DemoTimeSeries.FindAsync(id);
        //    if (demoTimeSeries == null)
        //    {
        //        return NotFound();
        //    }

        //    db.DemoTimeSeries.Remove(demoTimeSeries);
        //    await db.SaveChangesAsync();

        //    return Ok(demoTimeSeries);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DemoTimeSeriesExists(string id)
        //{
        //    return db.DemoTimeSeries.Count(e => e.Id == id) > 0;
        //}
    }
}