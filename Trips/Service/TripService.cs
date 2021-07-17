using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Config;
using Trips.Models;

namespace Trips.Service
{
    public class TripService : ITripServcie
    {
        private readonly Context _context;

        public TripService(Context ctx)
        {
            _context = ctx;
        }

        public void AddTrip(Travel trip)
        {
            _context.Travel.Add(trip);
            _context.SaveChanges();
        }

        public void DeleteTrip(int tripId)
        {
            var trip = _context.Travel.FirstOrDefault(t => t.Id == tripId);

            if (trip != null) 
            {
                _context.Travel.Remove(trip);
                _context.SaveChangesAsync();
            }
        }

        public List<Travel> GetAllTrips() => _context.Travel.ToList();

        public Travel GetTripById(int tripId) => _context.Travel.FirstOrDefault(t => t.Id == tripId);

        public void UpdateTrip(int tripId, Travel trip)
        {
            var oldTrip = _context.Travel.FirstOrDefault(t => t.Id == tripId);

            if (oldTrip != null) 
            {
                oldTrip.Name = trip.Name;
                oldTrip.Description = trip.Description;
                oldTrip.DateStarted = trip.DateStarted;
                trip.DateCompleted = trip.DateCompleted;

                 _context.SaveChangesAsync();
            }
        }
    }
}
