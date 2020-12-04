using CovidTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Services
{
    public interface IVenueService
    {
         void AddVenue(Venue venue);

         Task<Venue> FindVenueAsync(int? Id);

         void UpdateVenue(Venue venue);

         void DeleteVenue(Venue venue);

         Task SaveVenueAsync();

         Task<List<Venue>> GetVenueAsync();

         bool VenueExists(int id);

         

    }
}
