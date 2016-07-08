using System.Data.Entity;
using Data.Classes.Reference;
using Context;

namespace Context.Reference
{
    public class ReferenceContext:BaseContext<ReferenceContext>
    {
        public DbSet<SampleReference> Samples { get; set; }
        public DbSet<StatusReference> Statuses { get; set; }
        public DbSet<UserReference> Users { get; set; }
    }
}