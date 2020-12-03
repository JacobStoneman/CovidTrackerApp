using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CovidTrackerApp.Models;

namespace CovidTrackerApp.Data
{
    public class CovidTrackerAppContext : DbContext
    {
        public CovidTrackerAppContext (DbContextOptions<CovidTrackerAppContext> options)
            : base(options)
        {
        }

        public DbSet<CovidTrackerApp.Models.Venue> Venue { get; set; }

        public DbSet<CovidTrackerApp.Models.Patient> Patient { get; set; }

        public DbSet<CovidTrackerApp.Models.CareWorker> CareWorker { get; set; }
    }
}
