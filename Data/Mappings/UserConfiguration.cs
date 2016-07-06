using System.Data.Entity.ModelConfiguration;
using Data.Classes;

namespace Data.Mappings
{
    class UserConfiguration : EntityTypeConfiguration<Users>
    {
        public UserConfiguration()
        {
            HasKey(k => k.UserId);
            Property(r => r.FirstName).IsRequired();
            Property(r => r.LastName).IsRequired();
        }
    }
}
