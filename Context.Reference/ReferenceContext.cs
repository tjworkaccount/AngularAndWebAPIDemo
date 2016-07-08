using System.Data.Entity;
using Data.Classes.Reference;

namespace Context.Reference
{
    public class ReferenceContext:BaseContext<ReferenceContext>
    {
        public DbSet<StatusReference> Statuses { get; set; }
        public DbSet<UserReference> Users { get; set; }
    }
}