using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class SampleConfiguration : EntityTypeConfiguration<Sample>
    {
        public SampleConfiguration()
        {
            this.ToTable("Samples");
            this.Property(r => r.Id).HasColumnName("SampleId");
            this.Property(r => r.Barcode).IsRequired();
            this.Property(d => d.CreatedAt).HasColumnType("date");
            this.HasRequired(r => r.CreatedByUser).WithMany(r => r.Samples).HasForeignKey(fk => fk.CreatedBy);
            this.HasRequired(r => r.Status).WithMany(r => r.Samples).HasForeignKey(fk => fk.StatusId);
        }
    }
}
