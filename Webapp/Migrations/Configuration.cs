using Webapp.Models;

namespace Webapp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Webapp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Webapp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Languages.Add(new Language()
            {
                Name = "English"
            });

            context.Languages.Add(new Language()
            {
                Name = "Español"
            });

            context.Categories.Add(new Category()
            {
                Name = "Terror"
            });

            context.Categories.Add(new Category()
            {
                Name = "Suspenso"
            });

            context.Categories.Add(new Category()
            {
                Name = "Accion"
            });

            context.SaveChanges();
        }
    }
}
