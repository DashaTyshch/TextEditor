﻿using System.Data.Entity.Migrations;

namespace DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TextEditorDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TextEditorDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

    }
}
