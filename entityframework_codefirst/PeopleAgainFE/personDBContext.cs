using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    class PeopleDBContext : DbContext
    {
        public PeopleDBContext() : base("name=EFPeopleDatabase") { }
        public virtual DbSet<Person> People { get; set; }
    }
}
