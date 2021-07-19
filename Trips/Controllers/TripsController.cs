using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Models;
using Trips.Service;

namespace Trips.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private ITripServcie _service;

        public TripsController(ITripServcie service)
        {
            this._service = service;
        }

        // GET: TripsController
        [HttpGet("GetTrips")]
        public ActionResult GetTrips()
        {
            var allTrips = _service.GetAllTrips();

            return Ok(allTrips);
        }

        // GET: TripsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TripsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripsController/Create
        [HttpPost("AddTrip")]
        public ActionResult AddTrip([FromBody]Travel trip)
        {
            try
            {
                if (trip != null)
                {
                    _service.AddTrip(trip);
                }

                return RedirectToAction(nameof(GetTrips));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("SingleTrip/{id}")]
        public IActionResult GetTripById(int id)
        {
            var trip = _service.GetTripById(id);

            return Ok(trip);
        }

        // GET: TripsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPut("UpdateTrip/{id}")]
        public IActionResult UpdateTrip(int id, [FromBody]Travel trip)
        {
            _service.UpdateTrip(id, trip);

            return Ok(trip);
        }



        // POST: TripsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost("DeleteTrip/{id}")]
        public IActionResult DeleteTrip(int id)
        {
            _service.DeleteTrip(id);
            return Ok();
        }


        // POST: TripsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                return Ok();
            }
            catch
            {
                return View();
            }
        }
    }
}
