using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Models;

namespace Trips.Service
{
    public interface ITripServcie
    {
        List<Travel> GetAllTrips();
        Travel GetTripById(int tripId);
        void UpdateTrip(int tripId, Travel trip);
        void DeleteTrip(int tripId);
        void AddTrip(Travel trip);
    }
}
