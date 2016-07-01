using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class StatusConfiguration: EntityTypeConfiguration<Status>
    {
        public StatusConfiguration()
        {
            this.ToTable("Statuses");
            this.Property(r => r.Id).HasColumnName("StatusId").IsRequired();
            this.Property(r => r.Value).HasColumnName("Status").IsRequired();
        }
    }
}