using System.Data.Entity.ModelConfiguration;

namespace Webapp.Models.EntitiesConfiguration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            HasKey(movie => movie.Id);
            Property(movie => movie.Description).IsRequired();
            Property(movie => movie.Director).IsRequired();
            HasIndex(movie => movie.Title).IsUnique();

            HasRequired(movie => movie.Language)
                .WithMany(la => la.Movies)
                .HasForeignKey(movie => movie.LanguageId);

            HasRequired(movie => movie.OrginalLanguage)
                .WithMany(la => la.OriginalLanguageMovies)
                .HasForeignKey(movie => movie.OriginalLanguageId).WillCascadeOnDelete(false);

            HasMany(movie => movie.Categories)
                .WithMany(c => c.Movies)
                .Map(cs =>
                {
                    cs.MapLeftKey("MovieId");
                    cs.MapRightKey("CustomerId");
                    cs.ToTable("MovieCategories");
                });

            HasRequired(movie => movie.ApplicationUser)
                .WithMany(la => la.Movies)
                .HasForeignKey(movie => movie.ApplicationUserId);
        }
    }
}