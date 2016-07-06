using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class StatusConfiguration: EntityTypeConfiguration<Statuses>
    {
        public StatusConfiguration()
        {
            HasKey(k => k.StatusId);
            Property(r => r.Status).IsRequired();
        }
    }
}