using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class StatusConfiguration: EntityTypeConfiguration<Statuses>
    {
        public StatusConfiguration()
        {
            Property(r => r.StatusId).IsRequired();
            Property(r => r.Status).IsRequired();
        }
    }
}