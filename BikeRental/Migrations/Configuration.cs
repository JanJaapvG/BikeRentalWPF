namespace BikeRental.Migrations
{
    using BikeRental.Model;
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeRental.Model.BikeRentalModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BikeRentalModel context)
        {
            var bike1 = new Bike
            {
                Name = "Sonic Bike",
                Description = "Gotta Go Fast",
                Brand = "Speed",
                Type = Category.Racefiets,
                BikeSize = BikeSize.Large,
                Gender = Gender.Male,
                HourRate = 7.50,
                DailyRate = 14.75
            };

            var bike2 = new Bike
            {
                Name = "Herenfiets",
                Description = "Goede stadsfiest",
                Brand = "Gazelle",
                Type = Category.Stadsfiets,
                BikeSize = BikeSize.Large,
                Gender = Gender.Male,
                HourRate = 5.50,
                DailyRate = 12.75
            };

            var customer1 = new Customer
            {
                Id = 1,
                FirstName = "Appie",
                LastName = "Heijn",
                Gender = Gender.Male,
                Email = "Appie@Heijn.nl",
            };

            var customer2 = new Customer
            {
                Id = 2,
                FirstName = "Celine",
                LastName = "Duizend",
                Gender = Gender.Female,
                Email = "Celine@Duizend.nl",
            };

            var store1 = new Store
            {
                Id = 1,
                Name = "Fietsenwinkel Almere",
                Adress = "Fietslaan 1",
                City = "Almere",
                MaxCapacity = 1,
                Bikes = new ObservableCollection<Bike>() { bike1 }
            };

            var store2 = new Store
            {
                Name = "Fietsenwinkel Amsterdam",
                Adress = "Lelylaan 2",
                City = "Amsterdam",
                MaxCapacity = 1,
                Bikes = new ObservableCollection<Bike>() { bike2 }
            };

            var reservation1 = new Reservation {
                Start = new DateTime(2021, 03, 30, 13, 45, 00),
                End = new DateTime(2021, 04, 04, 13, 45, 00),
                Bike = bike1,
                Customer = customer1,
                DropoffStore = store1,
                PickupStore = store1
            };

            var reservation2 = new Reservation
            {
                Start = new DateTime(2021, 03, 30, 13, 45, 00),
                End = new DateTime(2021, 04, 04, 13, 45, 00),
                Bike = bike2,
                Customer = customer2,
                DropoffStore = store2,
                PickupStore = store2
            };

            store1.Reservations.Add(reservation1);
            store1.Customers.Add(customer1);
            store2.Reservations.Add(reservation2);
            store2.Customers.Add(customer2);

            context.Stores.AddOrUpdate(
                n => n.Name,
                store1,
                store2
                );

            context.Customers.AddOrUpdate(
                p => p.Email,
                customer1,
                customer2
                );
        }
    }
}


                    