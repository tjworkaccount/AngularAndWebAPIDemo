using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Data.Classes;
using Data.Context;
using EntityFramework.Seeder;

namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            CheckIndentCommand<Statuses>(ref context);
            context.Statuses.SeedFromStream(GetSeedStream<Statuses>(), c => c.StatusId);
            CheckIndentCommand<Users>(ref context);
            context.Users.SeedFromStream(GetSeedStream<Users>(), c => c.UserId);
            context.SaveChanges();

            var createdByMapping = new CsvColumnMapping<Samples>("CreatedBy",
                (sample, user) =>
                {
                    int id;
                    if (int.TryParse(user.ToString(), out id))
                    {
                        sample.CreatedByUser = context.Users.Single(u => u.UserId == id);
                    }
                });

            var statusIdMapping = new CsvColumnMapping<Samples>("StatusId",
                (sample, status) =>
                {
                    int id;
                    if (int.TryParse(status.ToString(), out id))
                    {
                        sample.Status = context.Statuses.Single(u => u.StatusId == id);
                    }
                });

            context.Samples.SeedFromStream(GetSeedStream<Samples>(), c => c.SampleId, new []{createdByMapping, statusIdMapping});
        }

        private static void CheckIndentCommand<T>(ref DataContext context, int reseedValue = 0) => 
            context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT ('{typeof(T).Name}', RESEED, {reseedValue})");

        private static Stream GetSeedStream<T>() =>
            Assembly.GetExecutingAssembly().GetManifestResourceStream("Data.Resources." + typeof(T).Name + ".csv");
    }
}