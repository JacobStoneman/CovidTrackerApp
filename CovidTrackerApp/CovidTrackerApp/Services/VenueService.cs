using CovidTrackerApp.Data;
using CovidTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Services
{
    public class VenueService : IVenueService
    {
        private readonly CovidTrackerAppContext _context = new CovidTrackerAppContext();


        public VenueService()
        {
        }

        public VenueService(CovidTrackerAppContext context)
        {
            _context = context;
        }

        public void AddVenue(Venue venue)
        {
            _context.Venue.Add(venue);
        }

        public async Task<Venue> FindVenueAsync(int? Id)
        {
            return await _context.Venue.FindAsync(Id);
        }

        public void UpdateVenue(Venue venue)
        {
            _context.Venue.Update(venue);
        }

        public void DeleteVenue(Venue venue)
        {
            _context.Venue.Remove(venue);

        }

        public async Task SaveVenueAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Venue>> GetVenueAsync()
        {
            return await _context.Venue.ToListAsync();
        }

        public bool VenueExists(int id)
        {
            return _context.Venue.Any(e => e.VenueId == id);
        }
    }
}
