using System.Data.Entity;

namespace BikeRental.Model
{
    public class BikeRentalModel : DbContext
    {
        public BikeRentalModel() : base("name=BikeRentalModel")
        {

        }

        public virtual DbSet<Bike> Bikes { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual  DbSet<Store> Stores { get; set; }

    }
}