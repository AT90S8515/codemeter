namespace CodeMeter.HttpService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeMeter.HttpService.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeMeter.HttpService.Models.DataContext";
        }

        protected override void Seed(CodeMeter.HttpService.Models.DataContext context)
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
            //context.Configurations.Add(new Models.Configuration()
            //{
            //    CheckRunning = true,
            //    CheckInterval = 1,
            //    NotificationInterval = 15,
            //    Recepient = "zeljko.bajsanski@gmail.com",
            //    Sender = "zeljko.bajsanski@brizb.rs",
            //    SendEmail = true,
            //    Smtp = "mail.brizb.rs",
            //    Port = 26,
            //    Username = "zeljko.bajsanski@brizb.rs",
            //    Password = "J0v4n4"
            //});
        }
    }
}
