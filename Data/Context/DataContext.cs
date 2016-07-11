using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Context;
using Data.Classes;

namespace Data.Context
{
    public class DataContext : BaseContext<DataContext> 
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Samples> Samples { get; set; }
        public DbSet<Statuses> Statuses { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
        //        .Where(type => !string.IsNullOrEmpty(type.Namespace))
        //        .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

        //    Debugger.Launch();

        //    //foreach (var type in typesToRegister)
        //    //{
        //    //    dynamic configurationInstance = Activator.CreateInstance(type);
        //    //    modelBuilder.Configurations.Add(configurationInstance);
        //    //}
        //}
    }
}