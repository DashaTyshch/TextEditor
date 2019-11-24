using DBAdapter.Migrations;
using DBAdapter.ModelConfiguration;
using DBModels;
using System.Data.Entity;

namespace DBAdapter
{
    class TextEditorDBContext : DbContext
    {
        public TextEditorDBContext() : base("TextEditorDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TextEditorDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new QueryConfiguration());
        }
    }
}
