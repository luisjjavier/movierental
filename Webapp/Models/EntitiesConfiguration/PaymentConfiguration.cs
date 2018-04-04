using System.Data.Entity.ModelConfiguration;

namespace Webapp.Models.EntitiesConfiguration
{
    public class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            HasKey(payment => payment.Id);
            HasRequired(payment => payment.ApplicationUser)
                .WithMany(applicationUser => applicationUser.Payments)
                .HasForeignKey(payment => payment.ApplicationUserId);

            HasMany(payment => payment.Rentals)
                .WithRequired(rental => rental.Payment)
                .HasForeignKey(payment => payment.PaymentId).WillCascadeOnDelete(false);
        }
    }
}