using DBModels;
using System.Data.Entity.ModelConfiguration;

namespace DBAdapter.ModelConfiguration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(u => u.Guid);

            Property(u => u.Guid)
                .HasColumnName("Guid")
                .IsRequired();

            Property(u => u.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            Property(u => u.LastName)
                .HasColumnName("LastName")
                .IsRequired();

            Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(256)
                .IsOptional();

            Property(u => u.Login)
                .HasColumnName("Login")
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.Password)
                .HasColumnName("Password")
                .IsRequired();

            Property(u => u.LastLoginDate)
                .HasColumnName("LastLoginDate")
                .IsRequired();

            HasIndex(ind => new { ind.Email, ind.Login}).IsUnique(true);

            HasMany(s => s.Queries)
                .WithRequired()
                .WillCascadeOnDelete(true);
        }
    }
}
