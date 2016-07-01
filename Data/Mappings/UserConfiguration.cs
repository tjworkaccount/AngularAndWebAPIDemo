using System.Data.Entity.ModelConfiguration;
using System.Runtime.CompilerServices;
using Data.Classes;

namespace Data.Mappings
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("Users");
            this.Property(r => r.FirstName).IsRequired();
            this.Property(r => r.LastName).IsRequired();
        }
    }
}
