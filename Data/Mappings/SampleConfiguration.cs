using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class SampleConfiguration : EntityTypeConfiguration<Samples>
    {
        public SampleConfiguration()
        {
            Property(r => r.SampleId).IsRequired();
            Property(r => r.Barcode).IsRequired();
            Property(d => d.CreatedAt).HasColumnType("date");
            HasRequired(r => r.CreatedByUser).WithMany(r => r.Samples).HasForeignKey(fk => fk.CreatedBy).WillCascadeOnDelete(false);
            HasRequired(r => r.Status).WithMany(r => r.Samples).HasForeignKey(fk => fk.StatusId).WillCascadeOnDelete(false);
        }
    }
}
