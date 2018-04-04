using System.Data.Entity.ModelConfiguration;

namespace Webapp.Models.EntitiesConfiguration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(customer => customer.Id);
            Property(customer => customer.FirstName).IsRequired();
            Property(customer => customer.LastName).IsRequired();
            Property(customer => customer.Email).IsRequired();
            Property(customer => customer.Address).HasMaxLength(500);

            HasMany(customer => customer.Payments)
                .WithRequired(payment => payment.Customer)
                .HasForeignKey(payment => payment.CustomerId);
        }
    }
}