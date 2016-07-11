using Data.Classes;
using System.Data.Entity;

namespace Context.Sample
{
    public class SampleContext:BaseContext<SampleContext>
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Samples> Samples { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
    }
}
