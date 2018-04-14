using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Flights
{
    public  class FlightsDBContext : DbContext
    {
        public FlightsDBContext() : base("name=EFFlightsDatabase") { }
        public virtual DbSet<Flight> Flight { get; set; }
    }
}
