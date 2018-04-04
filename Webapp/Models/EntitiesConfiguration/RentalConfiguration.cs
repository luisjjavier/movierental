using System.Data.Entity.ModelConfiguration;

namespace Webapp.Models.EntitiesConfiguration
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            HasKey(rental => rental.Id);
            HasRequired(rental => rental.ApplicationUser)
                .WithMany(applicationUser => applicationUser.Rentals)
                .HasForeignKey(rental => rental.ApplicationUserId);

            HasRequired(payment => payment.RentMovie)
                .WithMany(movie => movie.Rentals)
                .HasForeignKey(rental => rental.RentMovieId).WillCascadeOnDelete(false);
        }
    }
}