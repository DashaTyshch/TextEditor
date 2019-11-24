using DBModels;
using System.Data.Entity.ModelConfiguration;

namespace DBAdapter.ModelConfiguration
{
    class QueryConfiguration : EntityTypeConfiguration<Query>
    {
        public QueryConfiguration()
        {
            ToTable("Query");
            HasKey(q => q.Guid);

            Property(q => q.Guid)
                .HasColumnName("Guid")
                .IsRequired();

            Property(q => q.FilePath)
                .HasColumnName("FilePath")
                .IsRequired();

            Property(q => q.QueryDate)
                .HasColumnName("QueryDate")
                .IsRequired();

            Property(q => q.State)
                .HasColumnName("State")
                .IsRequired();
        }
    }
}
